using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public GameObject FloorPrefab;
    public GameObject BatPrefab;
    public GameObject SimePrefab;
    public GameObject PlantPrefab;
    public CharacterManager characterManager;
    private GameObject[][] Map = new GameObject[32][];
    

    private void Awake()
    {
        for (int i = 0;i< 32;i++)
        {
            Map[i] = new GameObject[32];
        }
        characterManager = new CharacterManager();
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
        GameObject Bat = Instantiate(BatPrefab, new Vector3(2, -2, transform.position.z), Quaternion.identity);
        Bat.GetComponent<BatCharacter>().stage = this;
        GameObject Plant = Instantiate(PlantPrefab, new Vector3(2, -6, transform.position.z), Quaternion.identity);
        GameObject Slime = null;
        characterManager.setCharacter(Plant, Bat, Slime);
        



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
