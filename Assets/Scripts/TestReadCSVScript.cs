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
                if (Map[i, j] == "3")
                {
                    GameObject newWall = Instantiate(TilePrefabs.WallPrefab, new Vector3(i, j, transform.position.z), Quaternion.identity);
                    newWall.name = "Wall" + i.ToString() + "_" + j.ToString();

                } else if (Map[i, j] == "1")
                {

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
