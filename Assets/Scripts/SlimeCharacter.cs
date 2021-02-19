using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCharacter : MonoBehaviour, ICharacter
{
    Vector3 position;
    Vector3 newPosition;
    CharacterManager characterManager;


    public void move(Vector3 newPosition)
    {
        this.newPosition = newPosition;
    }

    public void setPosition(int x, int y)
    {
        
    }
    public void getVision()
    {
        throw new System.NotImplementedException();
    }
    public GameObject getGameObject()
    {
        return gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        characterManager = GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Vector3.Equals(newPosition, position)) 
        {
            Vector3 diff = newPosition - position;
            if (diff.x != 0f && diff.y != 0f)
            {
                MoveTo(new Vector3(diff.x / Mathf.Abs(diff.x), diff.y / Mathf.Abs(diff.y), diff.z));
            }
           /* else if (diff.Key != 0) MoveTo(new KeyValuePair<int, int>(diff.Key / Mathf.Abs(diff.Key), 0));
            else MoveTo(new KeyValuePair<int, int>(0, diff.Value / Mathf.Abs(diff.Value)));*/
        }

    }

    void MoveTo(Vector3 diffVector)
    {
        /*position = new KeyValuePair<int, int>(position.Key + diffVector.Key, position.Value + diffVector.Value);
        //interact with something
        TileMap.Tile tile = GetComponent<MapController>().tilemap[position.Key][position.Value];*/
        
        return ;
    }

    Vector3 getPosition()
    {
        throw new System.NotImplementedException();
    }

    Vector3 ICharacter.getPosition()
    {
        throw new System.NotImplementedException();
    }
}
