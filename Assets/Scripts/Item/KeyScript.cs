using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour, Interactable
{
    private GameController stage;
    public int interact(bool isFirstHand, Vector3 direction)
    {
        stage.SetMapGameObject((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, null);
        stage.key++;
        Destroy(gameObject);
        return 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("MapManager").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
