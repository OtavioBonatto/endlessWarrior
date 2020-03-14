using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    public AudioSource[] soundEffects;
    private AudioSource _audioSource;
     private void Awake() {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
     }

     public void PlaySFX(int soundToPlay) {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        soundEffects[soundToPlay].Play();
     }
 
     public void PlayMusic() {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic() {
         _audioSource.Stop();
     }
}
