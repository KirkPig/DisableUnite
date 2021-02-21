using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3[] plantPosition;
    public static Vector3[] batPosition;
    public static Vector3[] slimePosition;
    public static List<ButtonClass>[] buttons;
    public static List<RisingFloorClass>[] risingFloors;
    public float char_val_z = 0f;

    void Awake()
    {
        plantPosition = new Vector3[6];
        batPosition = new Vector3[6];
        slimePosition = new Vector3[6];
        buttons = new List<ButtonClass>[6];
        risingFloors = new List<RisingFloorClass>[6];
        //Begin PlantPosition
        //stage 0: 9 18
        plantPosition[0] = new Vector3(9f, 18f, char_val_z);
        //stage 1: 15 22
        plantPosition[1] = new Vector3(15f, 22f, char_val_z);
        //stage 2: 7 24
        plantPosition[2] = new Vector3(7f, 24f, char_val_z);
        //stage 3: 7 10
        plantPosition[3] = new Vector3(7f, 10f, char_val_z);
        //stage 4: 9 22
        plantPosition[4] = new Vector3(9f, 22f, char_val_z);
        //stage 5: 20 14
        plantPosition[5] = new Vector3(20f, 14f, char_val_z);
        //End PlantPosition

        //Begin batPosition
        //stage 0: 9 22
        batPosition[0] = new Vector3(9f, 22f, char_val_z);
        //stage 1: 9 23
        batPosition[1] = new Vector3(9f, 23f, char_val_z);
        //stage 2: 14 16
        batPosition[2] = new Vector3(14f, 16f, char_val_z);
        //stage 3: 7 10
        batPosition[3] = new Vector3(7f, 10f, char_val_z);
        //stage 4: 9 22
        batPosition[4] = new Vector3(9f, 22f, char_val_z);
        //stage 5: 13 14
        batPosition[5] = new Vector3(13f, 14f, char_val_z);
        //End batPosition

        //Begin slimePosition
        //stage 0: null
        //stage 1: null
        //stage 2: null
        //stage 3: null
        //stage 4: 15 18
        slimePosition[4] = new Vector3(15f, 18f, char_val_z);
        //stage 5: 14 19
        slimePosition[5] = new Vector3(14f, 19f, char_val_z);
        //End slimePosition
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
