using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour, Interactable
{

    public bool open = false;
    public bool state;
    private GameController stage;

    public int interact(bool isFirstHand, Vector3 direction)
    {
        return open ? 1 : 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!state) open = (stage.gateStatus == 0);
        else open = (stage.gateStatus > 0);
        GetComponent<Animator>().SetBool("Open", open);    
    }
    

}
