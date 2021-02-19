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
         * 
         */
        GameObject Bat = Instantiate(BatPrefab, new Vector3(9, 21, transform.position.z), Quaternion.identity);
        Bat.GetComponent<BatCharacter>().stage = this;
        GameObject Plant = Instantiate(PlantPrefab, new Vector3(9, 17, transform.position.z), Quaternion.identity);
        Plant.GetComponent<PlantCharacter>().stage = this;
        GameObject Slime = null;
        characterManager.setCharacter(Plant, Bat, Slime);

        Map[9][21] = Bat;
        Map[9][17] = Plant;



    }

    public GameObject GetMapGameObject(int i, int j)
    {
        Debug.Log("request" + i.ToString() + j.ToString());
        return Map[i][j];
    }
    public void SetMapGameObject(int i, int j, GameObject smth)
    {
        Map[i][j] = smth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
