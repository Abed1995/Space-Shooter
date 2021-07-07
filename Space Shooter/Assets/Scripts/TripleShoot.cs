using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShoot : MonoBehaviour
{
    float _speed = 1;
   

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
}
