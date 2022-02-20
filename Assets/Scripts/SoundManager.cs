using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    AudioSource source;

    void Start()
    {
        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent<AudioSource>();
        }

        source = GetComponent<AudioSource>();
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound != null) {
            source.PlayOneShot(sound.clip);
        }
    }

    public void PlayStay(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        if (sound != null) {
            AudioSource.PlayClipAtPoint(sound.clip, Camera.main.transform.position);
        }
    }
}
