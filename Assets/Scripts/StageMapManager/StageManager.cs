using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public GameObject FloorPrefab;
    public GameObject BatPrefab;
    public GameObject SimePrefab;
    public GameObject PlantPrefab;

    private GameObject[][] Map = new GameObject[32][];

    public GameObject Bat;
    public GameObject Slime;
    public GameObject Plant;

    private void Awake()
    {
        for (int i = 0;i< 32;i++)
        {
            Map[i] = new GameObject[32];
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        /*
         * Floor Generated
         */
        for (int i = 0;i<9;i++)
        {
            for (int j = 0;j < 9;j++)
            {
                if (i == 4 && j == 4)
                {

                }
                else
                {

                    GameObject NewGameObject = Instantiate(FloorPrefab, new Vector3(j, -i, transform.position.z), Quaternion.identity, transform);
                    NewGameObject.name = "Floor" + i.ToString() + "_" + j.ToString();

                    Map[i][j] = NewGameObject;

                }
            }
        }

        /*
         * 
         */
        Bat = Instantiate(BatPrefab, new Vector3(2, -2, transform.position.z), Quaternion.identity);
        Plant = Instantiate(PlantPrefab, new Vector3(2, -6, transform.position.z), Quaternion.identity);
        Slime = null;




    }

    public GameObject GetMapGameObject(int i, int j)
    {
        return Map[i][j];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
