using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private AudioClip[] _audioClips;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        _audio.clip = _audioClips[index];
        _audio.Play();
    }
    

}
