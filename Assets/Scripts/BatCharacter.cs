using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCharacter : MonoBehaviour, ICharacter, Interactable
{
    //begin ICharacter 
    public Vector3 position;
    public StageManager stage;
    public void move(Vector3 newPosition)
    {
        gameObject.transform.position = newPosition;
    }
    public void getVision()
    {
    
    }
    public void setPosition(int x, int y)
    {
        
    }
    public Vector3 getPosition()
    {
        return position;
    }
   public GameObject getGameObject()
    {
        return gameObject;
    }
    //End ICharacter

    //begin Interactable
    public int interact(bool isCharacter, KeyValuePair<int, int> direction)
    {
        return 0;
    }
    //end Interactable
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
