using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public ICharacter bat;
    public ICharacter tree;
    public ICharacter slime;
    public ICharacter selectedCharacter;
    public float cooldown;
    public float cooldownTime;
    void Start()
    {
        cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = Mathf.Max(0f, cooldown - Time.deltaTime);
        if (cooldown > 0f) return; 
        if (Input.GetAxis("Vertical") != 0)
        {
            int x;
            if (Input.GetAxis("Vertical") < 0)
            {
                x = -1;
            }
            else x = 1;
            selectedCharacter.move(new KeyValuePair<int, int>(0, x));
            cooldown = cooldownTime;

        }
        else if(Input.GetAxis("Horizontal") !=  0)
        {
            int x;
            if (Input.GetAxis("Horizontal") < 0)
            {
                x = -1;
            }
            else x = 1;
            selectedCharacter.move(new KeyValuePair<int, int>(x, 0));
            cooldown = cooldownTime;
        }
    }
    void alarm(KeyValuePair<int, int> newPosition)
    {
        slime.move(newPosition);
    }

}
