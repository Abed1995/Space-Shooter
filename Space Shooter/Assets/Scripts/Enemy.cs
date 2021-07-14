using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    GameObject EnemyExplosion;

    [SerializeField]
    AudioClip _explosionClip ;

    [SerializeField]
    bool _canRotate;
    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime , Space.World);
        if (transform.position.y< -6 && _canRotate ==false )
        {
            transform.position = new Vector3(transform.position.x, 6.3f, 0);
        }

        if (_canRotate )
        {
            transform.Rotate ( Vector3.back , 2);
            if (transform.position.y < -6)
            {
                Destroy(this.gameObject);
            }
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);

           
            Destroy(this.gameObject);
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(_explosionClip, Camera.main.transform.position);
            uIManager.UpdateScore();

            if (other.transform.parent.gameObject != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
        }

       else if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(_explosionClip, Camera.main.transform.position);
            Player player = other.GetComponent<Player>();
            uIManager.UpdateScore();

            player.Damage();
        }

    }
}
