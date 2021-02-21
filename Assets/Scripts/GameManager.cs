using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    private List<AsyncOperation> LoadingOps;
    public string stageSelected = "Stage0";


    private void Awake()
    {

        instance = this;
        LoadingOps = new List<AsyncOperation>();

    }

    

    // Start is called before the first frame update
    void Start()
    {

        
        LoadingOps.Add(SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Additive));

        StartCoroutine(LoadingCheck().GetEnumerator());

    }

    public void BackMainMenu()
    {
        LoadingOps.Add(SceneManager.UnloadSceneAsync("Stage0"));
        LoadingOps.Add(SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Additive));

        StartCoroutine(LoadingCheck().GetEnumerator());
    }

    public void RestartGame(string stage)
    {
        LoadingOps.Add(SceneManager.UnloadSceneAsync("Stage0"));
        LoadingOps.Add(SceneManager.LoadSceneAsync("Stage0", LoadSceneMode.Additive));

        StartCoroutine(LoadingCheck(stage).GetEnumerator());
    }

    public void StartGame(string stage)
    {
        LoadingOps.Add(SceneManager.UnloadSceneAsync("MainMenuScene"));
        LoadingOps.Add(SceneManager.LoadSceneAsync("Stage0", LoadSceneMode.Additive));

        StartCoroutine(LoadingCheck(stage).GetEnumerator());

    }

    /*

    public void StageSelectSceneLoad()
    {

        LoadingOps.Add(SceneManager.UnloadSceneAsync("MainMenuScene"));
        LoadingOps.Add(SceneManager.LoadSceneAsync("StageSelectScene", LoadSceneMode.Additive));

        StartCoroutine(LoadingCheck().GetEnumerator());

    }

    public void MainMenuSceneLoad()
    {
        LoadingOps.Add(SceneManager.UnloadSceneAsync("StageSelectScene"));
        LoadingOps.Add(SceneManager.LoadSceneAsync("MainMenuScene", LoadSceneMode.Additive));

        StartCoroutine(LoadingCheck().GetEnumerator());
    }
    */

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

    IEnumerable LoadingCheck(string stage)
    {

        loadingScreen.SetActive(true);
        // Debug.Log("Loading..");

        for (int i = 0; i < LoadingOps.Count; i++)
        {
            while (!LoadingOps[i].isDone)
            {
                yield return null;
            }
        }

        // Debug.Log("Loading Done");
        LoadingOps.Clear();

        

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Stage0"));

        GameObject.Find("GameController").GetComponent<GameController>().csvFile = Resources.Load("MapCSV/" + stage, typeof(TextAsset)) as TextAsset;
        GameObject.Find("GameController").GetComponent<GameController>().buttonFile = Resources.Load("ButtonPointCSV/button" + stage, typeof(TextAsset)) as TextAsset;
        GameObject.Find("GameController").GetComponent<GameController>().spawnFile = Resources.Load("SpawnPointCSV/spawn" + stage, typeof(TextAsset)) as TextAsset;
        GameObject.Find("GameController").GetComponent<GameController>().stageName = stage;
        GameObject.Find("GameController").GetComponent<GameController>().LoadGame();
        GameObject.Find("GameManagerCam").GetComponent<Camera>().enabled = false;
        GameObject.Find("StageCam").GetComponent<Camera>().enabled = true;


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
