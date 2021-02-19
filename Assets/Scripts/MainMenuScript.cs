using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject StageSelectUI;
    public GameObject MainMenuUI;

    void Start()
    {
        StageSelectUI.SetActive(false);
        MainMenuUI.SetActive(true);

    }

    public void PlayButtonClicked()
    {
        MainMenuUI.SetActive(false);
        StageSelectUI.SetActive(true);
    }

    public void BackButtonClicked()
    {
        StageSelectUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
