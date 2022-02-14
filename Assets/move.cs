using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject o;

    private bool test;

    // Start is called before the first frame update
    void Start()
    {
        test = false;
    }

    public void Update()
    {
        if(test)
            this.transform.position = o.transform.position;
    }

    // Update is called once per frame
    public void Move()
    {
        test = true;
    }

    public void UnMove()
    {
        test = false;
    }
}
