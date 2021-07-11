using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Sprite[] lives;

    [SerializeField]
    Image LivesSprite;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    GameObject titlecreen;

    int score;

    // Start is called before the first frame update
   public void UpdateLives( int currentlives)
    {
        LivesSprite.sprite = lives[currentlives];
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score : " + score; 
    }

    public void ShowTitleScreen()
    {
        titlecreen.SetActive(true);
    }
    public void HideTitleScreen()
    {
        titlecreen.SetActive(false);
    }
}
