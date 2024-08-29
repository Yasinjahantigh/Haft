using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class levels_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load_level_1()
    {
        SceneManager.LoadScene(10);//10
    }

    public void load_level_2()
    {
        SceneManager.LoadScene(11);
    }

    public void load_level_3()
    {
        SceneManager.LoadScene(12);
    }

    public void load_level_4()
    {
        SceneManager.LoadScene(13);
    }

    public void load_level_5()
    {
        SceneManager.LoadScene(14);
    }

    public void load_level_6()
    {
        SceneManager.LoadScene(15);
    }

    public void next_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void next_and_edite_database()
    {
        string path = Path.Combine(Application.persistentDataPath, "data_game.csv");
        string[] lines = File.ReadAllLines(path);
        int num = int.Parse(lines[0]);

        print("num:");
        print(num);
        if (num == (SceneManager.GetActiveScene().buildIndex))
        {
            num = num + 1;
        }
        File.WriteAllText(path, num.ToString());


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu_asli()
    {
        SceneManager.LoadScene(0);
    }
}
