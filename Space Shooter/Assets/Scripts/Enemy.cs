using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float _speed;
    [SerializeField]
    GameObject EnemyExplosion;


    UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y< -6)
        {
            transform.position = new Vector3(transform.position.x, 6.3f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            uIManager.UpdateScore();
        }

       else if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);

            Player player = other.GetComponent<Player>();
            uIManager.UpdateScore();

            player.Damage();
        }

    }
}
