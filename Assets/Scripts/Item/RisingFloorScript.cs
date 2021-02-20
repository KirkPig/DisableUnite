using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingFloorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController stage;
    public Vector2Int activeRange;
    public bool isActive;
    void Start()
    {
        stage = GameObject.Find("GameController")
                .GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        isActive = (stage.currentRhytm + 1 >= activeRange.x && stage.currentRhytm + 1 <= activeRange.y);
        int x = (int)gameObject.transform.position.x, y = (int)gameObject.transform.position.y;
        GameObject goj;
        if ((goj = stage.GetMapGameObject(x, y)) != null)
        {
            if(goj.GetComponent<BlockScript>() != null)
            {
                stage.SetMapGameObject(x, y, null);
                Destroy(goj);
            }
            else
            {
                //restart 

            }
        }
    }
}
