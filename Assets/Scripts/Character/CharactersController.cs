using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkCooldown;
    public float walkCooldownTime;
    public float switchCooldown;
    public float switchCooldownTime;
    public GameObject mapManager;
    public CharacterManager characterManager;
    void Start()
    {
        spawn();
        characterManager =  mapManager.GetComponent<StageManager>().characterManager;
         
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
                characterManager.selectedCharacter.GetComponent<ICharacter>().move(new Vector3(characterManager.selectedCharacter.transform.position.x, 
                                                                            characterManager.selectedCharacter.transform.position.y + x, 
                                                                            characterManager.selectedCharacter.transform.position.z));
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
                characterManager.selectedCharacter.GetComponent<ICharacter>().move(new Vector3(characterManager.selectedCharacter.transform.position.x + 
                                                                                    x, characterManager.selectedCharacter.transform.position.y , 
                                                                                     characterManager.selectedCharacter.transform.position.z));
                walkCooldown = walkCooldownTime;
            }
        }
    }
    void spawn()
    {
        // do something
    }


}
