using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public double time;
    public double currentTime;
  
    // Start is called before the first frame update
    void Start()
    {

        time = gameObject.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            SceneManager.LoadScene(1);
        }
    }
  
}
