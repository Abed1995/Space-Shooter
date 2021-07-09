using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab;

    [SerializeField]
    GameObject[] powerups;

    int randomprefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstantiateEnemy());
        StartCoroutine(InstantiatePowerUP());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiateEnemy()
    {
        while (true)
        {
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator InstantiatePowerUP()
    {
        randomprefab = Random.Range(0, 3);
        Instantiate(powerups[randomprefab], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
        yield return new WaitForSeconds(3.0f);
    }
}
