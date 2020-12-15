using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kyle_dialogue : MonoBehaviour
{

    public AudioSource[] source;
    public AudioClip clip;
    public int i = 0;

    public void Awake()
    {

        source = GetComponents<AudioSource>();
       
    }

    public void OnTriggerEnter(Collider other)
    {
     
        if(!source[(i - 1 + source.Length) % source.Length].isPlaying)
            source[i++ % source.Length].Play();
        
    }
}
