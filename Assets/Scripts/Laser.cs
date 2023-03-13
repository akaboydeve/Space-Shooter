using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private bool _isEnemyLaser = false;


    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player") && _isEnemyLaser)
        {
            Player player = other.GetComponent<Player>();
            player.Damage();
        }
    }
    void CalculateMovement()
    {
        if (!_isEnemyLaser)
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

            if (transform.position.y > 8)
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject, 1f);
                }
                Destroy(this.gameObject, 1f);
            }
        }

        if (_isEnemyLaser)
        {

            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y > -8)
            {
                if (transform.parent != null)
                {
                    Destroy(transform.parent.gameObject, 1f);
                }
                Destroy(this.gameObject, 1f);
            }

            

        }

    }
}