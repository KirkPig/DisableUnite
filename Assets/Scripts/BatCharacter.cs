using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCharacter : MonoBehaviour, ICharacter, Interactable
{
    KeyValuePair<int, int> position;
    public KeyValuePair<int, int> getPosition()
    {
        return position;
    }
    bool notInRange(int x, int y) { return false; }
    public void move(KeyValuePair<int, int> direction)
    {
       
        
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

    public int interact(bool isCharacter, KeyValuePair<int, int> direction)
    {
        return 0;
    }
}
