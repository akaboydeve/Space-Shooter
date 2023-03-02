using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject laserPrefab;

    [SerializeField] private float fireRate = 0.1f;
    [SerializeField] private float nextFire = 0f;

    [SerializeField] private float Lives = 3;
    [SerializeField] private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("SpawnManager is NULL");
        }

    }

    // Update is called once per frame
    void Update()
    {

        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > nextFire))
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        //Input For the Movement
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        // moving the Player Game object using Translet
        // transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);
        // transform.Translate(new Vector3(0, 1, 0) * VerticalInput * speed * Time.deltaTime);

        // moving with single line
        Vector3 MovementDirection = new Vector3(HorizontalInput, VerticalInput, 0);
        transform.Translate(MovementDirection * speed * Time.deltaTime);


        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0.5f), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

    }

    public void Damage()
    {
        Lives--;
        if (Lives <= 0)
        {
            Destroy(this.gameObject);
            _spawnManager.OnPlayerDeath();

        }
    }

    public void FireLaser()
    {
        nextFire = fireRate + Time.time;
        Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

}
