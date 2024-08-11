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
        string content = "1\n1000\n10, 12, 14, 16, 18\n0.83333, 0.83333, 0.83333, 0.83333, 0.83333\n1, 2, 3, 4, 5\n7, 6, 5, 4, 3\n1\n1\n1\n1";

        // نوشتن محتوا رستم
        if (!File.Exists(path))
        {
            File.WriteAllText(path, content);
        }

        //نوشتن لول و دیتا مورد نیاز برای خود بازی

        string path_data_game = Path.Combine(Application.persistentDataPath, "data_game.csv");
        string content_d = "10";

        if (!File.Exists(path_data_game))
        {
            File.WriteAllText(path_data_game, content_d);
        }
        print(path);
    }

    // Update is called once per frame
    public void OnUpdateButtonClicked()
    {
        SceneManager.LoadScene(2);
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
