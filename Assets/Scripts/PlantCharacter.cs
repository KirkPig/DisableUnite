using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCharacter : MonoBehaviour, ICharacter, Interactable
{
    Vector3 position;
    public StageManager stage;
    //Begin Icharacter
    public Vector3 getPosition()
    {
        throw new System.NotImplementedException();
    }

    public void getVision()
    {
        throw new System.NotImplementedException();
    }

    public void move(Vector3 newPosition)
    {
        throw new System.NotImplementedException();
    }

    public void setPosition(int x, int y)
    {
        throw new System.NotImplementedException();
    }
    //Eind ICharacter

    //Begin Interactable
    public int interact(bool isCharacter, Vector3 direction)
    {
        position = gameObject.transform.position;
        if (!isCharacter) return 2;
        Vector3 newPosition = position + direction;
        int x = (int)newPosition.x, y = (int)newPosition.y;
        if (stage.GetMapGameObject(x, y) == null)
        {
            Debug.Log("Still here");
            Debug.Log(x.ToString() + " " + y.ToString());
            //stage.SetMapGameObject(x, y, gameObject);
            gameObject.transform.position = newPosition;
            return 1;
        }
        return 2;
    }
    //End Interactable

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
