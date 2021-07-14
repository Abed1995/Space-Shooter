using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] _enemyPrefab;

    [SerializeField]
    GameObject[] powerups;

    int randomPowerUpPrefab;
    int randomEnemyPrefab;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCouroutines()
    {
        StartCoroutine(InstantiateEnemy());
        StartCoroutine(InstantiatePowerUP());
    }

    IEnumerator InstantiateEnemy()
    {

        while (gameManager.gameOver == false)
        {
            randomEnemyPrefab = Random.Range(0, 2);
            Instantiate(_enemyPrefab[randomEnemyPrefab], new Vector3(Random.Range(-7, 8), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator InstantiatePowerUP()
    {
        while (gameManager.gameOver == false)
        {
            randomPowerUpPrefab = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUpPrefab], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(10.0f);
        }
       
    }
}
