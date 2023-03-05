using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class PowerUpAudio : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        {
            if ( _audioSource == null )
            {
                Debug.LogError("Audio Source NULL");
            }
        }
    }
    public void PlayPowerUpAudio()
    {
        _audioSource.Play();
    }
}
