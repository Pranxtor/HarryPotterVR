using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connected : MonoBehaviour
{
    public GameObject aRendreInvisible;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        aRendreInvisible.SetActive(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        // si l'objet rentre en colision avec le bon objet
        if (collision.gameObject == aRendreInvisible)
        {
            aRendreInvisible.SetActive(false);
            audioSource.PlayOneShot(clip, volume);
        }

    }
}
