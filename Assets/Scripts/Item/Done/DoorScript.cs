using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, Interactable
{
    private GameController stage;
    public int requirement;
    public int interact(bool isFirstHand, Vector3 direction)
    {
        if(stage.key >= requirement)
        {
            stage.key -= requirement;
            stage.SetMapGameObject((int)gameObject.transform.position.x, (int)gameObject.transform.position.y, null);
            Destroy(gameObject);
            return 1;
        }
        return 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
