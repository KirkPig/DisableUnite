using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable {
    int interact(bool isCharacter, Vector3 direction);
    /*return For Character     |  For Block
             1: Able to move   |  1: Able to move
             2: Can't move     |  2: Can't move
             3: Respawn        |  3: Destroy itself
    */         
} 
