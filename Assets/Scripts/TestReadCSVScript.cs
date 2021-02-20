using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReadCSVScript : MonoBehaviour
{
    // Start is called before the first frame update

    public TextAsset csvFile;

    void Start()
    {
        GenerateMap();

    }

    private void GenerateMap()
    {
        string[,] Map = ReadCSV.ReadCSVFile(csvFile.text);

        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                int tile_i_j = (int)Mathf.Floor(float.Parse(Map[i,j]));
                switch(tile_i_j){
                    case 1:
                        GameObject newWater = Instantiate(TilePrefabs.WaterPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newWater.name = "Water" + i.ToString() + "_" + j.ToString();
                        break;
                    case 2:
                        GameObject newLava = Instantiate(TilePrefabs.LavaPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newLava.name = "Lava" + i.ToString() + "_" + j.ToString();
                        break;
                    case 3:
                        GameObject newWall = Instantiate(TilePrefabs.WallPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newWall.name = "Wall" + i.ToString() + "_" + j.ToString();
                        break;
                    case 7:
                        GameObject newKey= Instantiate(TilePrefabs.KeyPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newKey.name = "Key" + i.ToString() + "_" + j.ToString();
                        break;
                    case 8:
                        if(Map[i,j] == "8.1")
                        {
                            GameObject newDoor1 = Instantiate(TilePrefabs.Door1Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor1.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            break;
                        }
                        if(Map[i,j] == "8.2")
                        {
                            GameObject newDoor2 = Instantiate(TilePrefabs.Door2Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor2.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            break;
                        }
                        if(Map[i,j] == "8.3")
                        {
                            GameObject newDoor3 = Instantiate(TilePrefabs.Door3Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor3.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            break;
                        }
                        if(Map[i,j] == "8.4")
                        {
                            GameObject newDoor4 = Instantiate(TilePrefabs.Door4Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor4.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            break;
                        }
                        if(Map[i,j] == "8.5")
                        {
                            GameObject newDoor5 = Instantiate(TilePrefabs.Door5Prefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newDoor5.name = "newDoor1 " + i.ToString() + "_" + j.ToString();
                            break;
                        }
                        break;
                    case 12:
                        GameObject newBlock= Instantiate(TilePrefabs.BlockPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newBlock.name = "Block" + i.ToString() + "_" + j.ToString();
                        break;
                    case 13:
                        GameObject newAlarm= Instantiate(TilePrefabs.AlarmPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newAlarm.name = "Alarm" + i.ToString() + "_" + j.ToString();
                        break;
                    case 14:
                        GameObject newOpenGate = Instantiate(TilePrefabs.GatePrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newOpenGate.name = "Gate" + i.ToString() + "_" + j.ToString();
                        newOpenGate.GetComponent<GateScript>().open = true;
                        break;
                    case 15:
                        GameObject newCloseGate = Instantiate(TilePrefabs.GatePrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                        newCloseGate.name = "Gate" + i.ToString() + "_" + j.ToString();
                        newCloseGate.GetComponent<GateScript>().open = false;
                        break;
                    case 16:
                        if (Map[i, j] == "16.2")
                        {

                            GameObject newClock = Instantiate(TilePrefabs.ClockPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newClock.name = "Clock" + i.ToString() + "_" + j.ToString();
                            newClock.GetComponent<ClockScript>().maxTime = 2;

                        }
                        else if (Map[i, j] == "16.3")
                        {

                            GameObject newClock = Instantiate(TilePrefabs.ClockPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newClock.name = "Clock" + i.ToString() + "_" + j.ToString();
                            newClock.GetComponent<ClockScript>().maxTime = 3;

                        }
                        break;

                    case 17:
                        if (Map[i, j] == "17.1")
                        {
                            GameObject newEndBat = Instantiate(TilePrefabs.EndBatPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newEndBat.name = "EndBat" + i.ToString() + "_" + j.ToString();
                        }
                        else if (Map[i, j] == "17.2")
                        {
                            GameObject newEndPlant = Instantiate(TilePrefabs.EndPlantPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newEndPlant.name = "EndPlant" + i.ToString() + "_" + j.ToString();
                        }
                        else if (Map[i, j] == "17.3")
                        {
                            GameObject newEndSlime = Instantiate(TilePrefabs.EndSlimePrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                            newEndSlime.name = "EndSlime" + i.ToString() + "_" + j.ToString();
                        }
                        break;

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
