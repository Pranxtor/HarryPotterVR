using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jouer(){
        SceneManager.LoadScene("ClassRoom");
    }

    public void Quitter(){
        Application.Quit();	
    }
}
