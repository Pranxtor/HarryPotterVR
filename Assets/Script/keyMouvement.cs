using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyMouvement : MonoBehaviour
{
    public float speed;
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {       
        newTarget();   
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            newTarget();
        }
    }

    void newTarget(){
        System.Random random = new System.Random();
        float yPos = random.Next(1,3);
        float xPos = random.Next(-5,5);
        float zPos = random.Next(-5,5);
        speed = random.Next(1,3);;
        target = new Vector3(xPos,yPos,zPos);
        
    }
}
