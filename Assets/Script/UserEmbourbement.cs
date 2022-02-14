using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserEmbourbement : MonoBehaviour
{
    public float speed;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(0, -1, 0);
        speed = 0.025f;
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

    void gameOver()
    {
      

    }
}
