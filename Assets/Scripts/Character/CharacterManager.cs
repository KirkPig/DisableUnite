using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager 
{
    public GameObject[] characters; // tree, bat, slime
    public int pointer;
    public GameObject selectedCharacter;
    // Start is called before the first frame update
    public CharacterManager() { pointer = 0; characters = new GameObject[3]; }
    public void setCharacter(GameObject a, GameObject b, GameObject c)
    {
        
        characters[0] = a;
        characters[1] = b;
        characters[2] = c;
        selectedCharacter = characters[pointer];
    }

    // Update is called once per frame

    public void SwitchCharacter()
    {
        pointer ^= 1;
        selectedCharacter = characters[pointer];
    }
    public void alarm(Vector3 newPosition)
    {
        characters[2].GetComponent<ICharacter>().move(newPosition);
    }
}
