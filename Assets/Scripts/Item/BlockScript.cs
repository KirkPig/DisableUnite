using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour, Interactable
{
    private GameController stage;
    public int interact(bool isFirstHand, Vector3 direction)
    {
        if (!isFirstHand) return 2;
        int x = (int) gameObject.transform.position.x, y = (int) gameObject.transform.position.y;
        int nx = x + (int)direction.x, ny = y + (int)direction.y;
        GameObject goj = stage.GetMapGameObject(nx, ny);
        if (goj == null)
        {
            stage.SetMapGameObject(nx, ny, gameObject);
            stage.SetMapGameObject(x, y, null);
            gameObject.transform.position += direction;
            return 1;
        }
        else
        {
            Interactable interaction = goj.GetComponent<Interactable>();
            if (interaction != null)
            {
                int response = interaction.interact(false, direction);
                if (response == 3)
                {
                    stage.SetMapGameObject(x, y, null);
                    Destroy(gameObject);
                    return 1;
                }
                else if (response == 1)
                {
                    stage.SetMapGameObject(nx, ny, gameObject);
                    stage.SetMapGameObject(x, y, null);
                    gameObject.transform.position += direction;
                }
                return response;
            }
        }
        return 2;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        stage = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
