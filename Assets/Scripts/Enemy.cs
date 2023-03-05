using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;
    private Player _player;
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _canPlayingAudio = true;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (_player == null )
        {
            Debug.LogError("Player is NULL");
        }

        if (_animator == null)
        {
            Debug.LogError("Animator is NULL");
        }
        if ( _audioSource == null )
        {
            Debug.LogError("Audio Source NULL");
        }
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -4f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 8, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _animator.SetTrigger("OnEnemyDeath");
            speed = 0;
            PlayDestroidAudio();
            Destroy(this.gameObject,1.5f);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            if(_player != null)
            {
                _player.AddScore(10);
            
            }
            _animator.SetTrigger("OnEnemyDeath");
            PlayDestroidAudio();
            speed = 0;
            Destroy(this.gameObject,1.5f);
        }


    }

    void PlayDestroidAudio()
    {
        if (_canPlayingAudio == true)
        {
            _audioSource.Play();
            _canPlayingAudio = false;
        }
    }
}