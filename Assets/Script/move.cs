using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject o;

    private bool grabed;

    // Start is called before the first frame update
    void Start()
    {
        grabed = false;
    }

    public void Update()
    {
        if(grabed)
            this.transform.position = o.transform.position;
    }

    // Update is called once per frame
    public void Move()
    {
        grabed = true;
    }

    public void UnMove()
    {
        grabed = false;
        this.transform.position = new Vector3(0,0,0);
    }
}
