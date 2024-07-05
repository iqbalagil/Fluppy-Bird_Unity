using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource sfx;

    [Header("--- Audio Clip ---")]
     public AudioClip coinTouch;
     public AudioClip backgroundMusic;
    public AudioClip jump;

    private void OnEnable()
    {
        Music.clip = backgroundMusic;
        Music.Play();
    }
    public void PlaySfx(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
