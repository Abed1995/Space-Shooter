using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _horizontalInput;
    float _verticalInput;

    [SerializeField]
     float _speed;

    [SerializeField]
    GameObject _laserPrefab;

    [SerializeField]
    GameObject _tripleLaserPrefab;

    [SerializeField]
    bool canTripleShoot;

    float _fireRate = .25f;
    float _canFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        controlPlayerBounds();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            ShootingLaser();
        }
    }

    void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * _speed * _horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * _verticalInput * Time.deltaTime);
    }

    void controlPlayerBounds()
    {
        //controlling horizontal movement  

        if (transform.position.x > 9.4f)
            transform.position = new Vector3(-9.4f, transform.position.y, 0);

        if (transform.position.x < -9.4f)
            transform.position = new Vector3( 9.4f, transform.position.y, 0);

        //controlling vertical movement  
        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x, 0, 0);
        if (transform.position.y < -4f)
            transform.position = new Vector3(transform.position.x, -4f, 0);

    }

    void ShootingLaser()
    {
        
            if (Time.time > _canFire)
            {
               if (canTripleShoot)
               {
                   Instantiate(_tripleLaserPrefab, transform.position + new Vector3(.34f, 1.4f , 0), Quaternion.identity);
               }
               else
                   Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

                _canFire = Time.time + _fireRate;
            }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Triple Shoot")
        {
            StartCoroutine(cannotTrippleShoot());
            Destroy(other.gameObject);
        }

    }

    

    IEnumerator cannotTrippleShoot()
    {
        canTripleShoot = true;
        yield return new WaitForSeconds(5);
        canTripleShoot = false;

    }
    
}
