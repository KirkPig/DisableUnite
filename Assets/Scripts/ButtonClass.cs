using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClass 
{
    // Start is called before the first frame update
    public Vector3 position;
    public Vector3 alarmDestination;
    public bool isAlarm;
    public bool stepOn;
    public List<Vector2Int> conveyer; //please enter begin and end of each conveyer next to each other
    public float cooldown;
    public float cooldownTime;

    public ButtonClass(Vector3 position, Vector3 alarmDestination, bool isAlarm, List<Vector2Int> conveyer,float cooldown, float cooldownTime)
    {
        this.position = position;
        this.alarmDestination = alarmDestination;
        this.isAlarm = isAlarm;
        this.conveyer = conveyer;
        this.cooldown = cooldown;
        this.cooldownTime = cooldownTime;
    }
}
