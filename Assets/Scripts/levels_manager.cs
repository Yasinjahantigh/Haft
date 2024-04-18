using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(2);
    }

    public void load_level_2()
    {
        SceneManager.LoadScene(3);
    }

    public void load_level_3()
    {
        SceneManager.LoadScene(4);
    }

    public void next_level()
    {
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
