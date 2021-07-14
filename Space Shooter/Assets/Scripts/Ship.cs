using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    float _speed = 3;


    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    

    private void Move()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
