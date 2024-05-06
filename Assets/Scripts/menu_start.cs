using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu_start : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject aboutUsPanel;
    
    void Start()
    {
        helpPanel.SetActive(false);
        aboutUsPanel.SetActive(false);
    }

    // Update is called once per frame
    public void OnUpdateButtonClicked()
    {
        SceneManager.LoadScene(5);
    }

    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnHelpButtonClicked()
    {
        helpPanel.SetActive(true);
    }

    public void OnCloseHelpButtonClicked()
    {
        helpPanel.SetActive(false);
    }

    public void OnAboutUsButtonClicked()
    {
        aboutUsPanel.SetActive(true);
    }

    public void OnCloseAboutUsButtonClicked()
    {
        aboutUsPanel.SetActive(false);
    }

    public void exit()
    {
        Application.Quit();
    }
}
