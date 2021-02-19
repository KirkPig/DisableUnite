using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadCSV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReadCSVFile()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadCSVFile(){
        StreamReader strReader = new StreamReader(/*Path*/)    
        bool endOfFile = false;
        while(!endOfFile){
            string data = strReader.ReadLine();
            if(data == null){
                endOfFile = true;
                break;
            }

            var data_value = data.Split(',');
            
        }
    }
}
