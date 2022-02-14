using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using PDollarGestureRecognizer;
using System.IO;
using UnityEngine.Events;

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButton;
    public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButton2;
    public float inputThreshold = 0.1f;
    public Transform movementSource;

    public float newPositionThresholdDistance = 0.05f;
    public GameObject debugCubePrefab;
    public GameObject positionParticules;
    public GameObject Teleporter;
    public bool creationMode = true;
    public string newGestureName;

    public float recognitionThreshold = 0.9f;

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> { }
    public UnityStringEvent OnRecognized;

    private List<Gesture> trainingSet = new List<Gesture>();
    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        Debug.Log(recognitionThreshold);
        string[] gestureFiles = Directory.GetFiles(Application.persistentDataPath, "*.xml");
        foreach(var item in gestureFiles)
        {
            trainingSet.Add(GestureIO.ReadGestureFromFile(item));
        }
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton2, out bool isPressed2, inputThreshold);

        //Start Movement
        if(!isMoving && isPressed && isPressed2)
        {
            StartMovement();
        }
        //End Movement
        else if(isMoving && (!isPressed || !isPressed2))
        {
            EndMovement();
        }
        //UpdateMovement
        else if(isMoving && isPressed && isPressed2)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);

        if(debugCubePrefab){
            Destroy(Instantiate(debugCubePrefab,positionParticules.transform.position,Quaternion.identity),3);
        }
        Teleporter.SetActive(false);     
    }
    void EndMovement()
    {
        Debug.Log("End Movement");
        isMoving = false;

        //Create gesture form position list
        Point[] pointArray = new Point[positionsList.Count];

        for(int i = 0 ; i< positionsList.Count ; i++){
            //pointArray[i] = positionsList[i];
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(positionsList[i]);
            pointArray[i] = new Point(screenPoint.x, screenPoint.y, 0);
        }

        Gesture newGesture = new Gesture(pointArray);
        //Add a new Gesture;
        if(creationMode){
            newGesture.Name = newGestureName;
            trainingSet.Add(newGesture);

            string filename = Application.persistentDataPath + "/" + newGestureName + ".xml";
            GestureIO.WriteGesture(pointArray,newGestureName,filename);
        }
        //recognize
        else{
            Result result = PointCloudRecognizer.Classify(newGesture, trainingSet.ToArray());
            Debug.Log(result.GestureClass + result.Score);

            if(result.Score > recognitionThreshold){
                OnRecognized.Invoke(result.GestureClass);
            }
        }
        Teleporter.SetActive(true);     
    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        Vector3 lastPosition = positionsList[positionsList.Count - 1];
        if(Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance){
            if(debugCubePrefab){
                Destroy(Instantiate(debugCubePrefab,positionParticules.transform.position,Quaternion.identity),3);
            }    

            positionsList.Add(movementSource.position);
        }
    }
}
