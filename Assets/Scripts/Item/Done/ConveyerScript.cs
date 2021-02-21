using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int state = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Animator>().SetInteger("State", state);

    }

    public void StateUp()
    {
        if (state >= 4)
        {
            state = 1;
        }
        else
        {
            state = state + 1;
        }
    }
}
