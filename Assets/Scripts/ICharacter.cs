using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    
    void move(KeyValuePair<int, int> direction);
    void setPosition(int x, int y);
    KeyValuePair<int,int> getPosition();

        
}
