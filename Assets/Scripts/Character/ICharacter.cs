using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    
    void move(Vector3 newPosition);
    void setPosition(int x, int y);
    Vector3 getPosition();

        
}
