using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCharacter : MonoBehaviour, ICharacter
{
    KeyValuePair<int, int> position;
    KeyValuePair<int, int> newPosition;
    CharacterManager characterManager;
    public KeyValuePair<int, int> getPosition()
    {
        return position;
    }

    public void move(KeyValuePair<int, int> direction)
    {
        newPosition = direction;
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
        if(!KeyValuePair<int, int>.Equals(newPosition, position)) 
        {
            KeyValuePair<int, int> diff = new KeyValuePair<int, int>( newPosition.Key - position.Key, newPosition.Value - position.Value );
            if (diff.Key != 0 && diff.Value != 0) MoveTo(new KeyValuePair<int, int>(diff.Key / Mathf.Abs(diff.Key), diff.Value / Mathf.Abs(diff.Value)));
            else if (diff.Key != 0) MoveTo(new KeyValuePair<int, int>(diff.Key / Mathf.Abs(diff.Key), 0));
            else MoveTo(new KeyValuePair<int, int>(0, diff.Value / Mathf.Abs(diff.Value)));
        }

    }

    void MoveTo(KeyValuePair<int, int> diffVector)
    {
        position = new KeyValuePair<int, int>(position.Key + diffVector.Key, position.Value + diffVector.Value);
        //interact with something
        TileMap.Tile tile = GetComponent<MapController>().tilemap[position.Key][position.Value];
        
        return ;
    }

    
}
