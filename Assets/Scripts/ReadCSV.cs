using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCSV
{

    public static string[,] ReadCSVFile(string csvText)
    {

        string[,] p = new string[34, 34];

        string[] lines = csvText.Split("\n"[0]);

        Debug.Log(lines.Length);

        for (int i = 0;i < 32;i++)
        {


            string[] col = lines[i].Split(","[0]);

            for (int j = 0;j < col.Length;j++)
            {
                p[j, 31 - i] = col[j].Trim();
            }
        }


        return p;


    }
    public static string[,] ReadCSVFileNoReverse(string csvText)
    {

        string[,] p = new string[34, 34];

        string[] lines = csvText.Split("\n"[0]);

        Debug.Log(lines.Length);

        for (int i = 0; i < lines.Length; i++)
        {


            string[] col = lines[i].Split(","[0]);

            for (int j = 0; j < col.Length; j++)
            {
                p[j, i] = col[j].Trim();
            }
        }


        return p;


    }

}
