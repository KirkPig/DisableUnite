using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{

    public int time = 1;
    public int maxTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Animator>().SetInteger("Time", time);
        time = (GameObject.Find("GameController").GetComponent<GameController>().currentRhytm % maxTime) + 1;
    }

    public void TimeUp()
    {
        if (time >= maxTime)
        {
            time = 1;
        }
        else
        {
            time = time + 1;
        }
    }
}
