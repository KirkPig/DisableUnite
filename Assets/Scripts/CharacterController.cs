using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkCooldown;
    public float walkCooldownTime;
    public float switchCooldown;
    public float switchCooldownTime;
    public CharacterManager characterManager;
    void Start()
    {
        spawn();
        characterManager = GetComponent<CharacterManager>();
        walkCooldown = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        walkCooldown = Mathf.Max(0f, walkCooldown - Time.deltaTime);
        switchCooldown = Mathf.Max(0f, switchCooldown - Time.deltaTime);
        if (switchCooldown <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            characterManager.SwitchCharacter();
            switchCooldown = switchCooldownTime;
        }
        else if (walkCooldown <= 0f && characterManager.pointer == 1)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                int x;
                if (Input.GetAxis("Vertical") < 0)
                {
                    x = -1;
                }
                else x = 1;
                characterManager.selectedCharacter.move(new KeyValuePair<int, int>(0, x));
                walkCooldown = walkCooldownTime;

            }
            else if (Input.GetAxis("Horizontal") != 0)
            {
                int x;
                if (Input.GetAxis("Horizontal") < 0)
                {
                    x = -1;
                }
                else x = 1;
                characterManager.selectedCharacter.move(new KeyValuePair<int, int>(x, 0));
                walkCooldown = walkCooldownTime;
            }
        }
    }
    void spawn()
    {
        // do something
    }
    void alarm(KeyValuePair<int, int> newPosition)
    {
        characterManager.characters[2].move(newPosition);
    }

}
