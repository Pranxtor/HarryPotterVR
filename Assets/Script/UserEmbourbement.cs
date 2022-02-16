using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserEmbourbement : MonoBehaviour
{
    public GameObject gameover;
    public float speed;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(0, -1, 0);
        speed = 0.025f;
        gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            gameOver();
        }
    }

    public IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void gameOver()
    {
        gameover.SetActive(true);
        StartCoroutine(wait());

    }
}
