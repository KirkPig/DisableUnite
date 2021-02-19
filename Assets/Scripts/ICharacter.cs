using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    
    void move(Vector3 newPosition);
    void getVision();
    void setPosition(int x, int y);
    Vector3 getPosition();

        
}
