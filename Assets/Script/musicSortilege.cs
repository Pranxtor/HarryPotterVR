using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSortilege : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float timeBetweenShots = 100f;
    float timer;
    void Update()
    {
        //timer = audioSource.time;
        timer += Time.deltaTime;
        if (timer > timeBetweenShots)
        {
            //if(audioSource.time > timer){
            audioSource.PlayOneShot(RandomClip());
            timer = 0;//}
        }
    }
    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }
    // Start is called before the first frame update
    void Start()
    {
        //audioSource.PlayOneShot(RandomClip());
    }

    // Update is called once per frame
}
