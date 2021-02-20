using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestReadCSVScript : MonoBehaviour
{
    // Start is called before the first frame update

    public TextAsset csvFile;
    void Start()
    {
        ReadCSV.ReadCSVFile(csvFile.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
