using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatVisionScript : MonoBehaviour
{

    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, 0);
    }
}
