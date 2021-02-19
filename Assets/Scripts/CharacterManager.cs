using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public ICharacter[] characters; // tree, bat, slime
    public int pointer;
    public ICharacter selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        characters = new ICharacter[3];
        pointer = 0;
        //selectedCharacter = characters[pointer];
    }

    // Update is called once per frame
    void Update()
    {
        selectedCharacter = characters[pointer]; 
    }
    public void SwitchCharacter()
    {
        pointer ^= 1;
    }
}
