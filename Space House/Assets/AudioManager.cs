using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }
    }

    private void Start()
    {
        // Play("BackgroundMusic");
    }

    public void Inside()
    {
        //reverb


        //stop playing background and play other music
        Pause("BackgroundMusic");

        //
    }
    public void Play (string name)
    {
        //find the sound in the sounds array such that the name 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }

        s.source.Play();
    }

    public void Pause(string name)
    {
        //find the sound in the sounds array such that the name 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }

        s.source.Pause();
    }
}
