using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TileMap;

public class MapController : MonoBehaviour
{
    private const int V = 15;
    public List<int> key_recieve = new List<int>();
    public Tile [][] tilemap = new Tile[15][];

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i<15;i++){
            tilemap[i] = new Tile[15];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void get_key(int key){
        key_recieve.Add(key);
    }

    void use_key(int key){
        key_recieve.Remove(key);
    }

}
