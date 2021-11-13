using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    private static AudioPlayerManager instance = null;
    private bool musicpause;
      private AudioSource audio;

      private void Awake()
      {
          if (instance == null)
          { 
               instance = this;
               DontDestroyOnLoad(gameObject);
               return;
          }
          if (instance == this) return; 
          Destroy(gameObject);
      }

      void Start()
      {
         audio = GetComponent<AudioSource>();
         musicpause = false;
         audio.Play();
      }

      void Update()
      {
        audio = GetComponent<AudioSource>();
        if (PauseMenu.IsPaused){
             audio.Pause();
             musicpause = true;
        }else if(musicpause){
            audio.Play();
            musicpause = false;
        }
      }
}
