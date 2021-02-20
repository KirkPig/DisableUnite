using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TextAsset csvFile;

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

        GenerateMap();

        Vector2 batStart = new Vector2(9, 20);
        Vector2 plantStart = new Vector2(9, 22);

        Bat = Instantiate(TilePrefabs.BatPrefab, new Vector3(batStart.x, batStart.y, transform.position.z), Quaternion.identity);
        GameObject Plant = Instantiate(TilePrefabs.PlantPrefab, new Vector3(plantStart.x, plantStart.y, transform.position.z), Quaternion.identity);
        // GameObject Slime = Instantiate(TilePrefabs.SlimePrefab, new Vector3(7, 15, transform.position.z), Quaternion.identity);
        // Slime.GetComponent<SlimeCharacter>().targetPosition = Slime.transform.position;
        characterManager.setCharacter(Plant, Bat, null);
        drum = 0f;
        Map[(int)batStart.x][(int)batStart.y] = Bat;
        Map[(int)plantStart.x][(int)plantStart.y] = Plant;
        // Map[7][15] = Slime;
        key = 0;


    }
    private void GenerateMap()
    {

        Instantiate(TilePrefabs.FloorPrefab, new Vector3(-0.5f, -0.5f, 0), Quaternion.identity) ;

        string[,] A = ReadCSV.ReadCSVFile(csvFile.text);

        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                int tile_i_j = (int)Mathf.Floor(float.Parse(A[i, j]));
                switch (tile_i_j)
                {
                    case 1:
                        GameObject newWater = Instantiate(TilePrefabs.WaterPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newWater.name = "Water" + i.ToString() + "_" + j.ToString();
                        Map[i][j] = newWater;
                        break;
                    case 2:
                        GameObject newLava = Instantiate(TilePrefabs.LavaPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newLava.name = "Lava" + i.ToString() + "_" + j.ToString();
                        Map[i][j] = newLava;
                        break;
                    case 3:
                        GameObject newWall = Instantiate(TilePrefabs.WallPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newWall.name = "Wall" + i.ToString() + "_" + j.ToString();
                        Map[i][j] = newWall;
                        break;
                    case 7:
                        GameObject newKey = Instantiate(TilePrefabs.KeyPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newKey.name = "Key" + i.ToString() + "_" + j.ToString();
                        Map[i][j] = newKey;
                        break;
                    case 8:
                        if (A[i, j] == "8.1")
                        {
                            GameObject newDoor1 = Instantiate(TilePrefabs.Door1Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor1.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            Map[i][j] = newDoor1;
                            break;
                        }
                        if (A[i, j] == "8.2")
                        {
                            GameObject newDoor2 = Instantiate(TilePrefabs.Door2Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor2.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            Map[i][j] = newDoor2;
                            break;
                        }
                        if (A[i, j] == "8.3")
                        {
                            GameObject newDoor3 = Instantiate(TilePrefabs.Door3Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor3.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            Map[i][j] = newDoor3;
                            break;
                        }
                        if (A[i, j] == "8.4")
                        {
                            GameObject newDoor4 = Instantiate(TilePrefabs.Door4Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor4.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            Map[i][j] = newDoor4;
                            break;
                        }
                        if (A[i, j] == "8.5")
                        {
                            GameObject newDoor5 = Instantiate(TilePrefabs.Door5Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor5.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            Map[i][j] = newDoor5;
                            break;
                        }
                        break;
                    case 12:
                        GameObject newBlock = Instantiate(TilePrefabs.BlockPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newBlock.name = "Block" + i.ToString() + "_" + j.ToString();
                        Map[i][j] = newBlock;
                        break;
                    case 13:
                        GameObject newAlarm = Instantiate(TilePrefabs.AlarmPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newAlarm.name = "Alarm" + i.ToString() + "_" + j.ToString();
                        Map[i][j] = newAlarm;
                        break;
                    case 14:
                        GameObject newOpenGate = Instantiate(TilePrefabs.GatePrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newOpenGate.name = "Gate" + i.ToString() + "_" + j.ToString();
                        newOpenGate.GetComponent<GateScript>().open = true;
                        Map[i][j] = newOpenGate;
                        break;
                    case 15:
                        GameObject newCloseGate = Instantiate(TilePrefabs.GatePrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newCloseGate.name = "Gate" + i.ToString() + "_" + j.ToString();
                        newCloseGate.GetComponent<GateScript>().open = false;
                        Map[i][j] = newCloseGate;
                        break;
                    case 16:
                        if (A[i, j] == "16.2")
                        {

                            GameObject newClock = Instantiate(TilePrefabs.ClockPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newClock.name = "Clock" + i.ToString() + "_" + j.ToString();
                            newClock.GetComponent<ClockScript>().maxTime = 2;
                            Map[i][j] = newClock;

                        }
                        else if (A[i, j] == "16.3")
                        {

                            GameObject newClock = Instantiate(TilePrefabs.ClockPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newClock.name = "Clock" + i.ToString() + "_" + j.ToString();
                            newClock.GetComponent<ClockScript>().maxTime = 3;
                            Map[i][j] = newClock;

                        }
                        break;

                    case 17:
                        if (A[i, j] == "17.1")
                        {
                            GameObject newEndBat = Instantiate(TilePrefabs.EndBatPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newEndBat.name = "EndBat" + i.ToString() + "_" + j.ToString();
                            // Map[i][j] = newEndBat;
                        }
                        else if (A[i, j] == "17.2")
                        {
                            GameObject newEndPlant = Instantiate(TilePrefabs.EndPlantPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newEndPlant.name = "EndPlant" + i.ToString() + "_" + j.ToString();
                            // Map[i][j] = newEndPlant;
                        }
                        else if (A[i, j] == "17.3")
                        {
                            GameObject newEndSlime = Instantiate(TilePrefabs.EndSlimePrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newEndSlime.name = "EndSlime" + i.ToString() + "_" + j.ToString();
                            // Map[i][j] = newEndSlime;
                        }
                        break;

                }
            }
        }
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
            if(characterManager.selectedCharacter == Bat){
                getNoise();
            }
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
                if(Map[i][j]!=null){
                    var alarm = Map[i][j].GetComponent<AlarmScript>();
                    if(alarm != null)
                    {
                        bat_vision.Add(Map[i][j].transform.position);
                    }
                    //var clock = Map[i][j].GetComponent<ClockScript>();
                    //var plant = Map[i][j].GetComponent<PlantCharacter>();
                }
            }
        }
        Bat.GetComponent<BatCharacter>().getVision(bat_vision);
    }
}
