using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideSound : MonoBehaviour
{
    public bool inside = false;

    public AudioSource[] sounds;
    public AudioSource outsideMusic;
    public AudioSource insideMusic;
    public AudioSource stinger;
    public AudioClip clip;

    public AudioReverbZone reverb;

    public void Awake()
    {
        sounds = GetComponents<AudioSource>();
        outsideMusic = sounds[0];
        insideMusic = sounds[1];
        stinger = sounds[2];

        outsideMusic.Play();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            inside = !inside;
        // add/remove reverb
        reverb = other.GetComponent<AudioReverbZone>();

        //remove background music
        if (inside)
        {
            outsideMusic.Stop();
            stinger.Play();
            insideMusic.Play();


            reverb.reverbPreset = AudioReverbPreset.StoneCorridor;
        }
        else //outside
        {
            //play background music
            insideMusic.Stop();
            stinger.Play();
            outsideMusic.Play();

            reverb.reverbPreset = AudioReverbPreset.Plain;
        }
    }


}
