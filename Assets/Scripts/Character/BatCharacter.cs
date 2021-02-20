using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatCharacter : MonoBehaviour, ICharacter, Interactable
{
    public GameObject NoisePrefab; 
    //begin ICharacter 
    public Vector3 position;
    public GameController stage;
    private void Awake() {
        NoisePrefab = Resources.Load("Jade/Noise", typeof(GameObject)) as GameObject;
    }
    public void move(Vector3 newPosition)
    {
        position = gameObject.transform.position;
        int x = (int) newPosition.x, y = (int) newPosition.y;
        //Debug.Log(x.ToString() + " " + y.ToString());
        GameObject inNewPosition = stage.GetMapGameObject(x, y);
        if(inNewPosition == null)
        {
            gameObject.transform.position = newPosition;
            stage.SetMapGameObject((int)position.x, (int)position.y, null);
            stage.SetMapGameObject(x, y, gameObject);
        }
        else if(inNewPosition.GetComponent<Interactable>() != null) 
        {
            Interactable interaction = inNewPosition.GetComponent<Interactable>();
            Debug.Log("current position:" + position.x.ToString() + " " + position.y.ToString());
            int result = interaction.interact(true, newPosition - position);
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
         
        }
        
    }
    public void getVision(List<Vector3> voices)
    {
        foreach (Vector3 voice in voices){
            Vector3 dir = transform.position-voice;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            object p = Instantiate(NoisePrefab,voice,rotation);
        }
    }
    public void setPosition(int x, int y)
    {
        
    }
    public Vector3 getPosition()
    {
        return position;
    }
   public GameObject getGameObject()
    {
        return gameObject;
    }
    //End ICharacter

    //begin Interactable
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
    //end Interactable
    void Start()
    {
        position = transform.position;
        stage = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    
}
