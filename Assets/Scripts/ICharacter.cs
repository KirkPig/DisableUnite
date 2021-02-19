using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    
    void move(KeyValuePair<int, int> newPosition);
    void getVision();
    void setPosition(int x, int y);
    KeyValuePair<int,int> getPosition();
    GameObject getGameObject();

        
}
