using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text testScore;

    int score;
    float elapsedSeconds = 0;
    bool isRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedSeconds += Time.deltaTime;
            score = (int)elapsedSeconds;
        }
        testScore.text = score.ToString();
    }
    public void StopGameTimer() 
    {
        isRunning = false;
    }
}
