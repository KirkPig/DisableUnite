using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 position;
    public Vector3 alarmDestination;
    public bool isAlarm;
    public bool stepOn;
    public List<Vector2Int> conveyer; //please enter begin and end of each conveyer next to each other
    public float cooldown;
    public float cooldownTime;
    public GameController stage;
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        position = gameObject.transform.position;
        GameObject goj = stage.GetMapGameObject((int)position.x, (int)position.y);
        cooldown = Mathf.Max(0f, cooldown - Time.deltaTime);
        if (goj != null)
        {
            if(cooldown <= 0) 
            { 
                cooldown = cooldownTime;
                AlarmAndConveyer();
            }
            if (!stepOn)
            {
                stepOn = true;
                stage.InverseGate();
            }
        }
        else if(stepOn)
        {
            stage.InverseGate();
            stepOn = false;
        }
    }
    void AlarmAndConveyer()
    {
        if (isAlarm)
        {
            stage.characterManager.alarm(alarmDestination);
        }
        if (conveyer.Count != 0)
        {
            for (int i = 0; i < conveyer.Count; i += 2)
            {
                Vector2Int direction = conveyer[i + 1] - conveyer[i];
                if (direction.x != 0) direction.x /= Mathf.Abs(direction.x);
                if (direction.y != 0) direction.y /= Mathf.Abs(direction.y);
                for (Vector2Int j = new Vector2Int(conveyer[i + 1].x, conveyer[i + 1].y); j != conveyer[i] - direction; j -= direction)
                {
                    GameObject onConveyer = stage.GetMapGameObject(j.x, j.y);
                    if (onConveyer != null)
                    {
                        GameObject onNextBlock = stage.GetMapGameObject(j.x + direction.x, j.y + direction.y);
                        if (onNextBlock == null)
                        {
                            stage.SetMapGameObject(j.x + direction.x, j.y + direction.y, onConveyer);
                            stage.SetMapGameObject(j.x, j.y, null);
                        }
                        else
                        {
                            Interactable interaction = onNextBlock.GetComponent<Interactable>();
                            if (interaction != null)
                            {
                                int response = interaction.interact(true, new Vector3((float)direction.x, (float)direction.y, onConveyer.transform.position.z));
                                if (response == 1)
                                {
                                    stage.SetMapGameObject(j.x + direction.x, j.y + direction.y, onConveyer);
                                    stage.SetMapGameObject(j.x, j.y, null);
                                }
                                else if (response == 3)
                                {
                                    //restart
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
