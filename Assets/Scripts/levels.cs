using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;


public class levels : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public Button btn6;


    void Start()
    {
        string path_data_game = Path.Combine(Application.persistentDataPath, "data_game.csv");
        string[] lines = File.ReadAllLines(path_data_game);

        if (int.Parse(lines[0]) == 10)
        {
            btn2.interactable = false;
            btn3.interactable = false;
            btn4.interactable = false;
            btn5.interactable = false;
            btn6.interactable = false;

        }
        else if (int.Parse(lines[0]) == 11)
        {
            btn3.interactable = false;
            btn4.interactable = false;
            btn5.interactable = false;
            btn6.interactable = false;

        }
        else if (int.Parse(lines[0]) == 12)
        {
            btn4.interactable = false;
            btn5.interactable = false;
            btn6.interactable = false;

        }

        else if (int.Parse(lines[0]) == 13)
        {
            btn5.interactable = false;
            btn6.interactable = false;

        }

        else if (int.Parse(lines[0]) == 14)
        {
            btn6.interactable = false;

        }
        print(lines[0]);
    }

    public void BackButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        print("hh");
    }

}
