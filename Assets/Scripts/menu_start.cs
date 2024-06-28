using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class menu_start : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject aboutUsPanel;
    
    void Start()
    {
        helpPanel.SetActive(false);
        aboutUsPanel.SetActive(false);


        string path = Path.Combine(Application.persistentDataPath, "data.csv");
        string content = "1\n0\n15\n6\n2\n12";

        // نوشتن محتوا در فایل
        if (!File.Exists(path))
        {
            File.WriteAllText(path, content);
        }
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
