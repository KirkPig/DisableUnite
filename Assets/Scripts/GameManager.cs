using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    private List<AsyncOperation> LoadingOps;

    private void Awake()
    {

        instance = this;
        LoadingOps = new List<AsyncOperation>();

    }

    

    // Start is called before the first frame update
    void Start()
    {

        
        LoadingOps.Add(SceneManager.LoadSceneAsync("TestScene", LoadSceneMode.Additive));

        StartCoroutine(LoadingCheck().GetEnumerator());

    }

    IEnumerable LoadingCheck()
    {

        loadingScreen.SetActive(true);
        // Debug.Log("Loading..");

        for (int i = 0;i < LoadingOps.Count; i++)
        {
            while (!LoadingOps[i].isDone)
            {
                yield return null;
            }
        }

        // Debug.Log("Loading Done");
        LoadingOps.Clear();
        loadingScreen.SetActive(false);
        
    }

    void SaveGame()
    {

    }

    // Update is called once per frame
    void Update()
    {

        

    }
}
