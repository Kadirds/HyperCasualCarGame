using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake () {
        if (instance == null)
           instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.source;
        }
    }
    private void Start()
    {
        //Theme  Play("");
    }
    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: "+ name + "b�yle bir�ey yok bizimi kopar�yorsun");
            return;
        }
        s.source.Play();
    }
}
