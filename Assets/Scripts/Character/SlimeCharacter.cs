using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCharacter : MonoBehaviour, ICharacter, Interactable
{
    public Vector3 position;
    public Vector3 targetPosition;
    public GameController stage;
    

    public void move(Vector3 newPosition)
    {
        targetPosition = newPosition;
    }

    public void setPosition(int x, int y)
    {
        
    }
    public void getVision()
    {
        throw new System.NotImplementedException();
    }
    public GameObject getGameObject()
    {
        return gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        position = gameObject.transform.position;
        if(!Vector3.Equals(targetPosition, position)) 
        {
            Vector3 diff = targetPosition - position;
            if (diff.x != 0f && diff.y != 0f)
            {
                MoveTo(new Vector3(diff.x / Mathf.Abs(diff.x), diff.y / Mathf.Abs(diff.y), diff.z));
            }
            else if (diff.x != 0) MoveTo(new Vector3(diff.x/ Mathf.Abs(diff.x), 0, diff.z));
            else MoveTo(new Vector3(0, diff.y / Mathf.Abs(diff.y), diff.z));
        }

    }

    void MoveTo(Vector3 diffVector)
    {
        position = gameObject.transform.position;
        Vector3 newPosition = position + diffVector;
        int x = (int)newPosition.x, y = (int)newPosition.y;
        //Debug.Log(x.ToString() + " " + y.ToString());
        GameObject inNewPosition = stage.GetMapGameObject(x, y);
        if (inNewPosition == null)
        {
            gameObject.transform.position = newPosition;
            stage.SetMapGameObject((int)position.x, (int)position.y, null);
            stage.SetMapGameObject(x, y, gameObject);
        }
        else if (inNewPosition.GetComponent<Interactable>() != null)
        {
            Interactable interaction = inNewPosition.GetComponent<Interactable>();
            int result = interaction.interact(true, diffVector);
            if (result == 1)
            {
                gameObject.transform.position = newPosition;
                stage.SetMapGameObject((int)position.x, (int)position.y, null);
                stage.SetMapGameObject(x, y, gameObject);
            }
            else if (result == 3)
            {
                //restart
            }
            else
            {
                targetPosition = position;
            }

        }
        return ;
    }

    public Vector3 getPosition()
    {
        throw new System.NotImplementedException();
    }

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
            stage.SetMapGameObject((int)position.x, (int)position.y, null);
            gameObject.transform.position = newPosition;
            return 1;
        }
        else if (inNewPosition.GetComponent<Interactable>() != null)
        {
            int result = inNewPosition.GetComponent<Interactable>().interact(false, direction);
            if (result == 1)
            {
                stage.SetMapGameObject(x, y, gameObject);
                stage.SetMapGameObject((int)position.x, (int)position.y, null);
                gameObject.transform.position = newPosition;
                return 1;
            }
            else if (result == 3)
                return 3;
        }
        return 2;
    }
}
