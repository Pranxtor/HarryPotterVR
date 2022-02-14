using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setBoolGrab : MonoBehaviour
{
    public bool grabbing;
    public GameObject Sol;
    public GameObject fire;
    public GameObject gameover;
    public GameObject SceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
        this.grabbing = false;
        gameover.SetActive(false);
        SceneChanger.SetActive(false);
    }

    public void setGrab()
    {
        this.grabbing = true;
    }

    public void setUngrab()
    {
        this.grabbing = false;
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Fire()
    {
        if(!this.grabbing)
        {
            // Set on fire the player
            fire.SetActive(true);
            gameover.SetActive(true);
            StartCoroutine(wait());
            SceneChanger.SetActive(false);

        }else{
            fire.SetActive(false);
            gameover.SetActive(false);
            SceneChanger.SetActive(true);
            Sol.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
