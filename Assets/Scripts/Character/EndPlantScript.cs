using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlantScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameController stage;
    public bool isEndPlant;
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
        isEndPlant = false;
    }

    // Update is called once per frame
    void Update()
    {
        int x = (int)transform.position.x, y = (int)transform.position.y;
        GameObject goj = stage.GetMapGameObject(x, y);
        isEndPlant = (goj != null && goj.GetComponent<PlantCharacter>() != null);
    }
}
