using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objects;

    public GameObject  parent;

    private Behaviour bhvr;

    void Start(){
        if(parent!= null){
            foreach (Transform child in parent.transform){
                bhvr = child.gameObject.GetComponent<XRGrabInteractable>();
                bhvr.enabled = false;
            }    
        }
    }

    public void Spawn(string objectName)
    {
        foreach(var item in objects)
        {
            item.SetActive(objectName == item.name);
        }

        if(objectName == "Accio")
            Accio();
        else{
            UnAccio();
        }
    }

    public void Accio(){
        if(parent!= null){
            foreach (Transform child in parent.transform){
                bhvr = child.gameObject.GetComponent<XRGrabInteractable>();
                bhvr.enabled = true;
            }   
        }
        
    }

    public void UnAccio(){
        if(parent!= null){
            foreach (Transform child in parent.transform){
                bhvr = child.gameObject.GetComponent<XRGrabInteractable>();
                bhvr.enabled = false;
            }   
        }
        
    }
}
