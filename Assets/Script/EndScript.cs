using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(22);
        SceneManager.LoadScene("MenuPrincipal");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }
}
