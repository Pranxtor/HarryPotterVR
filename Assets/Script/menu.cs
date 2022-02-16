using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class menu : MonoBehaviour
{
    public GameObject menuObj;
    public XRNode inputSource;
    public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButton;

    bool menudDisplayed = false;

    void Start()
    {
        ResumeGame ();
    }

    void Update()
    {
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed);

        if(isPressed){
            Debug.Log(menudDisplayed);
            if(menudDisplayed){
                menudDisplayed = false;
                ResumeGame ();
            }
            else{
                menudDisplayed = true;
                PauseGame ();
            }
        }
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
        menuObj.SetActive(true);
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
        menuObj.SetActive(false);
    }

    public void RechargerSalle ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quitter ()
    {
        
    }
}
