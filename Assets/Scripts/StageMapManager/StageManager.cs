using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public GameObject FloorPrefab;
    public GameObject BatPrefab;
    public GameObject SlimePrefab;
    public GameObject PlantPrefab;
    public GameObject AlarmPrefab;
    public GameObject MainCamera;
    public bool gateStatus;
    public CharacterManager characterManager;
    public GameObject BatVision;
    private GameObject[][] Map = new GameObject[32][];
    private GameObject Bat;
    

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
        Bat = Instantiate(BatPrefab, new Vector3(9, 21, transform.position.z), Quaternion.identity);
        GameObject Plant = Instantiate(PlantPrefab, new Vector3(9, 17, transform.position.z), Quaternion.identity);
        GameObject Slime = Instantiate(SlimePrefab, new Vector3(7, 15, transform.position.z), Quaternion.identity);
        Slime.GetComponent<SlimeCharacter>().targetPosition = Slime.transform.position;
        GameObject Alarm = Instantiate(AlarmPrefab, new Vector3(7, 21, transform.position.z), Quaternion.identity);
        characterManager.setCharacter(Plant, Bat, Slime);

        Map[9][21] = Bat;
        Map[9][17] = Plant;
       // Map[7][21] = Alarm;
        Map[7][15] = Slime;



    }

    public void InverseGate()
    {
        gateStatus = !gateStatus;
    }

    public GameObject GetMapGameObject(int i, int j)
    {
        //Debug.Log("request" + i.ToString() + j.ToString());
        return Map[i][j];
    }
    public void SetMapGameObject(int i, int j, GameObject smth)
    {
        Map[i][j] = smth;
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = characterManager.selectedCharacter.transform;
        MainCamera.transform.position = new Vector3(t.position.x, t.position.y, MainCamera.transform.position.z);

        if (characterManager.selectedCharacter == Bat)
        {
            BatVision.SetActive(true);
        }
        else
        {
            BatVision.SetActive(false);
        }

    }
}
