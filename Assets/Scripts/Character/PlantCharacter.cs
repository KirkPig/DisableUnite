using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCharacter : MonoBehaviour, ICharacter, Interactable
{
    Vector3 position;
    public GameController stage;
    public float cooldown;
    public const float cooldownTime = 0.25f;
    //Begin Icharacter
    public Vector3 getPosition()
    {
        throw new System.NotImplementedException();
    }

    public void getVision()
    {
        throw new System.NotImplementedException();
    }

    public void move(Vector3 newPosition)
    {
        //do nothing
        
    }

    public void setPosition(int x, int y)
    {
        throw new System.NotImplementedException();
    }
    //End ICharacter

    //Begin Interactable
    public int interact(bool isFirstHand, Vector3 direction)
    {
        position = gameObject.transform.position;
        if (!isFirstHand) return 2;
        Vector3 newPosition = position + direction;
        int x = (int)newPosition.x, y = (int)newPosition.y;
        GameObject inNewPosition = stage.GetMapGameObject(x, y);
        if (inNewPosition == null)
        {
            stage.SetMapGameObject(x, y, gameObject);
            stage.SetMapGameObject((int) position.x, (int) position.y, null);
            gameObject.transform.position = newPosition;
            return 1;
        }
        else if(inNewPosition.GetComponent<Interactable>()!= null)
        {
            int result = inNewPosition.GetComponent<Interactable>().interact(false, direction);
            if(result == 1)
            {
                stage.SetMapGameObject(x, y, gameObject);
                stage.SetMapGameObject((int)position.x, (int)position.y, null);
                gameObject.transform.position = newPosition;
                return 1;
            }
            else if(result == 3) 
                return 3;
        }
        return 2;
    }
    //End Interactable

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = Mathf.Max(0f, cooldown - Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Q) && cooldown <= 0f)
        {
            stage.characterManager.alarm(transform.position);
            cooldown = cooldownTime;
        }
    }
}
