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


    void Start()
    {
        string userName = Environment.UserName;
        string text = File.ReadAllText("C:\\Users\\"+userName+"\\Documents\\7\\data.csv");
        string[] lines = text.Split('\n');

        if (int.Parse(lines[0]) == 1)
        {
            btn2.interactable = false;
            btn3.interactable = false;
        }
        else if (int.Parse(lines[0]) == 2)
        {
            btn3.interactable = false;
        }
        print(lines[0]);
    }

    public void BackButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        print("hh");
    }

}
