using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private int _PowerUpId;
    [SerializeField] private PowerUpAudio _powerupAudio;
    private void Start()
    {
        _powerupAudio = GameObject.Find("PowerUpAudio").GetComponent<PowerUpAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -4.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {

                _powerupAudio.PlayPowerUpAudio();

                switch (_PowerUpId)
                {

                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                    default:
                        Debug.Log("PowerUpID not Defined");
                        break;
                }

            }
            Destroy(this.gameObject);
        }
    }
}
