using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject FloorPrefab;
    public GameObject BatPrefab;
    public GameObject SlimePrefab;
    public GameObject PlantPrefab;
    public GameObject ButtonPrefab;
    public GameObject MainCamera;
    public bool gateStatus;
    public int key;
    public int currentRhytm;
    public float drum;
    public float drumTime;
    public CharacterManager characterManager;
    public GameObject BatVision;
    private GameObject[][] Map = new GameObject[32][];
    private GameObject Bat;
    private List<Vector3> bat_vision;
    

    private void Awake()
    {
        FloorPrefab = TilePrefabs.FloorPrefab;
        BatPrefab = TilePrefabs.BatPrefab;
        SlimePrefab = TilePrefabs.SlimePrefab;
        PlantPrefab = TilePrefabs.PlantPrefab;
        ButtonPrefab = TilePrefabs.ButtonPrefab;
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
        GameObject Button = Instantiate(ButtonPrefab, new Vector3(7, 21, transform.position.z), Quaternion.identity);
        characterManager.setCharacter(Plant, Bat, Slime);
        drum = 0f;
        Map[9][20] = Bat;
        Map[9][22] = Plant;
        Map[15][18] = Slime;
        key = 0;


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
        drum += Time.deltaTime;
        if (drum > drumTime)
        {
            currentRhytm = (currentRhytm + 1) % 6;
            drum = 0;
            getNoise();
        }
        if (characterManager.selectedCharacter == Bat)
        {
            BatVision.SetActive(true);
        }
        else
        {
            BatVision.SetActive(false);
        }

    }

    void getNoise(){
        bat_vision = new List<Vector3>();
        for (int i = 0;i< 32;i++)
        {
            for (int j = 0;j< 32;j++)
            {
                var alarm = Map[i][j].GetComponent<AlarmScript>();
                if(alarm != null){
                    bat_vision.Add(Map[i][j].transform.position);
                }
                //var clock = Map[i][j].GetComponent<ClockScript>();
                //var plant = Map[i][j].GetComponent<PlantCharacter>();
            }
        }
        Bat.GetComponent<BatCharacter>().getVision(bat_vision);
    }
}
