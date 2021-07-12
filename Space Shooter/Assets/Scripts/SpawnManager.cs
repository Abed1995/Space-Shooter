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
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator InstantiatePowerUP()
    {
        while (gameManager.gameOver == false)
        {
            randomprefab = Random.Range(0, 3);
            Instantiate(powerups[2], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(15.0f);
        }
       
    }
}
