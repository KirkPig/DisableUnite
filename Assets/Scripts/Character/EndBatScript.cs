using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBatScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameController stage;
    public bool isEndBat;
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
        isEndBat = false;
    }

    // Update is called once per frame
    void Update()
    {
        int x = (int) transform.position.x, y = (int) transform.position.y;
        GameObject goj = stage.GetMapGameObject(x, y);
        isEndBat =  (goj != null && goj.GetComponent<BatCharacter>() != null) ;
    }
}
