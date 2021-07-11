using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;

    public GameObject player;

    UIManager uIManager;




    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                uIManager.HideTitleScreen();
                gameOver = false;
            }
        }
    }

   
}
