using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyOutOfBonds();

    }

    void Move()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

    }

    private void DestroyOutOfBonds()
    {
        if (transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }
    }
}
