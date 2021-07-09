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
    GameObject _shieldPrefab;

    [SerializeField]
    GameObject _laserPrefab;

    [SerializeField]
    GameObject _tripleLaserPrefab;

    [SerializeField]
    GameObject _PlayerExplosion;

    [SerializeField]
    bool canTripleShoot;

    float _fireRate = .25f;
    float _canFire = 0.0f;

    [SerializeField]
    static  bool _shieldIsActive = false;

    static int lives = 3;

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

    public void Damage()
    {

        if (_shieldIsActive == true)
        {
            _shieldIsActive = false;
            _shieldPrefab.SetActive(false);
            return;
        }
        
            lives--;
            if (lives < 1)
            {
                //Instantiate(_PlayerExplosion, transform.position, Quaternion.identity);
                Debug.Log("haha");
                Destroy(gameObject);
            }
            Debug.Log(lives);
        

        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Triple Shoot")
        {
            StartCoroutine(cannotTrippleShoot());
            Destroy(other.gameObject);
        }
        else  if (other.gameObject.tag == "Speed Boost")
        {
            StartCoroutine(changingspeed());
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Shield")
        {
            _shieldIsActive = true;
            _shieldPrefab.SetActive(true);
            Destroy(other.gameObject);
        }


    }

    

    IEnumerator cannotTrippleShoot()
    {
        canTripleShoot = true;
        yield return new WaitForSeconds(5);
        canTripleShoot = false;

    }

    IEnumerator changingspeed()
    {
        _speed = 10;
        yield return new WaitForSeconds(5);
        _speed = 5;
    }
    
}
