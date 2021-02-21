using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSlimeScript : MonoBehaviour
{
    GameController stage;
    public bool isEndSlime;
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
        isEndSlime = false;
    }

    // Update is called once per frame
    void Update()
    {
        int x = (int)transform.position.x, y = (int)transform.position.y;
        GameObject goj = stage.GetMapGameObject(x, y);
        isEndSlime = (goj != null && goj.GetComponent<SlimeCharacter>() != null) 
       
    }
}
