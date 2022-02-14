using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    public string LevelToLoad;
    //public InputActionReference sceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        //sceneChanger.action.performed += HandleSceneChanger;
    }

    /*void HandleSceneChanger(InputAction.CallbackContext obj){
        Debug.Log("change");
        LoadLevel();
    }*/


    public void LoadLevel()
    {          
        SceneManager.LoadScene(LevelToLoad);
    }
}
