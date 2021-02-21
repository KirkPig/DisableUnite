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
    public void setCharacter(GameObject plant, GameObject bat, GameObject slime)
    {
        
        characters[0] = plant;
        characters[1] = bat;
        characters[2] = slime;
        selectedCharacter = characters[pointer];
    }

    public void setCharacterPlant(GameObject plant)
    {

        characters[0] = plant;
        selectedCharacter = characters[pointer];
    }

    public void setCharacterBat(GameObject bat)
    {

        characters[1] = bat;
        selectedCharacter = characters[pointer];
    }

    public void setCharacterSlime(GameObject slime)
    {

        characters[2] = slime;
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
