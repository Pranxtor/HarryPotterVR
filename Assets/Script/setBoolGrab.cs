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

    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);
        this.grabbing = false;
        gameover.SetActive(false);
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
        yield return new WaitForSeconds(400);
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

        }else{
            fire.SetActive(false);
            gameover.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
