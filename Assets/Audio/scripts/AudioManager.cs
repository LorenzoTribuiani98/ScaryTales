using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.outputAudioMixerGroup = sound.mixerGroup;
        }
        
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        sound.source.Play();
    }
}
