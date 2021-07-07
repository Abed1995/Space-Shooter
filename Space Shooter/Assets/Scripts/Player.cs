using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;

    [SerializeField]
     float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        controlPlayerBounds();
    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
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
}
