using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCharacter : MonoBehaviour, ICharacter
{
    KeyValuePair<int, int> position;
    public KeyValuePair<int, int> getPosition()
    {
        return position;
    }
    bool notInRange(int x, int y) { return false; }
    public void move(KeyValuePair<int, int> direction)
    {
       // GameObject goj;
        //if(notInRange(position.Key + direction.Key, position.Value + direction.Value)) { return;  }
        /*if(goj == null)
        {
            setPosition(position.Key + direction.Key, position.Value + direction.Value);
        }*/
        // if(goj is ICharacter){ }
        
    }

    public void setPosition(int x, int y)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
