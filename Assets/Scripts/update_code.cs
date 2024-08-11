using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using UnityEditor;


public class update_code : MonoBehaviour
{
    public TMP_Text textMesh_joon, textMesh_pool, textMesh_sorat, textMesh_khanjar, textMesh_zoor, textMesh_gorz;
    // Start is called before the first frame update
    public int joon, pool, sorat, zoor, gorz, sorat_lvl, khanjar_lvl, zoor_lvl, gorz_lvl;
    public float khanjar;
    public List<int> sorats, zoors, gorzes;
    public List<float> khanjars;

    public GameObject menu_ask_joon;
    public TMP_Text ask_box_joon_lvl, ask_box_joon_pool;

    public GameObject menu_ask_sorat;
    public TMP_Text ask_box_sorat_lvl, ask_box_sorat_pool;

    public GameObject menu_ask_khanjar;
    public TMP_Text ask_box_khanjar_lvl, ask_box_khanjar_pool;

    public GameObject menu_ask_zoor;
    public TMP_Text ask_box_zoor_lvl, ask_box_zoor_pool;

    public GameObject menu_ask_gorz;
    public TMP_Text ask_box_gorz_lvl, ask_box_gorz_pool;



    void get_and_update_data()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.csv");

        string[] lines = File.ReadAllLines(path);
        joon = int.Parse(lines[0]);
        pool = int.Parse(lines[1]);
        sorats = lines[2].Split(',').Select(int.Parse).ToList(); //in sorat = int.Parse(lines[2]);
        khanjars = lines[3].Split(',').Select(float.Parse).ToList(); //float khanjar = float.Parse(lines[3]);
        zoors = lines[4].Split(',').Select(int.Parse).ToList(); //int zoor = int.Parse(lines[4]);
        gorzes = lines[5].Split(',').Select(int.Parse).ToList(); //int gorz = int.Parse(lines[5]);
        sorat_lvl = int.Parse(lines[6]);
        khanjar_lvl = int.Parse(lines[7]);
        zoor_lvl = int.Parse(lines[8]);
        gorz_lvl = int.Parse(lines[9]);

        sorat = sorats[sorat_lvl - 1];
        khanjar = khanjars[khanjar_lvl - 1];
        zoor = zoors[zoor_lvl - 1];
        gorz = gorzes[gorz_lvl - 1];

        textMesh_joon.text = joon.ToString();
        textMesh_pool.text = pool.ToString();
        textMesh_sorat.text = sorat_lvl.ToString();
        textMesh_khanjar.text = khanjar_lvl.ToString();
        textMesh_zoor.text = zoor_lvl.ToString();
        textMesh_gorz.text = gorz_lvl.ToString();
    }
    void Start()
    {
        menu_ask_joon.SetActive(false);
        get_and_update_data();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void menu_asli()
    {
        SceneManager.LoadScene(0);
    }


    //-------------ask_joon---------------
    public void ask_joon_box_yes()
    {
        pool -= (joon + 1) * 5;
        joon++;

        string path = Path.Combine(Application.persistentDataPath, "data.csv");
        string[] lines = File.ReadAllLines(path);
        string content = $"{joon.ToString()}\n{pool.ToString()}\n{lines[2].ToString()}\n{lines[3].ToString()}\n{lines[4].ToString()}\n{lines[5].ToString()}\n{lines[6].ToString()}\n{lines[7].ToString()}\n{lines[8].ToString()}\n{lines[9].ToString()}";
        File.WriteAllText(path, content);
        get_and_update_data();

        menu_ask_joon.SetActive(false);
    }

    public void ask_joon_box_no()
    {
        menu_ask_joon.SetActive(false);
    }

    public void show_ask_joon()
    {
        if (pool >= joon * 5)
        {
            menu_ask_joon.SetActive(true);

            ask_box_joon_lvl.text = (joon + 1).ToString();
            ask_box_joon_pool.text = ((joon * 5)+5).ToString();
        }
    }


    //--------------ask_sorat--------------
    public void ask_sorat_box_yes()
    {
        pool -= (sorat_lvl + 1) * 5;
        sorat_lvl++;

        string path = Path.Combine(Application.persistentDataPath, "data.csv");
        string[] lines = File.ReadAllLines(path);
        string content = $"{joon.ToString()}\n{pool.ToString()}\n{lines[2].ToString()}\n{lines[3].ToString()}\n{lines[4].ToString()}\n{lines[5].ToString()}\n{sorat_lvl.ToString()}\n{lines[7].ToString()}\n{lines[8].ToString()}\n{lines[9].ToString()}";
        File.WriteAllText(path, content);
        get_and_update_data();

        menu_ask_sorat.SetActive(false);
    }

    public void ask_sorat_box_no()
    {
        menu_ask_sorat.SetActive(false);
    }

    public void show_ask_sorat()
    {
        if ((pool >= (sorat_lvl * 5)) && sorat_lvl < 5)
        {
            menu_ask_sorat.SetActive(true);

            ask_box_sorat_lvl.text = (sorat_lvl + 1).ToString();
            ask_box_sorat_pool.text = (((sorat_lvl) * 5) + 5).ToString();
        }
    }

    //-------------ask_khanjar---------------
    public void ask_khanjar_box_yes()
    {
        pool -= (khanjar_lvl + 1) * 5;
        khanjar_lvl++;

        string path = Path.Combine(Application.persistentDataPath, "data.csv");
        string[] lines = File.ReadAllLines(path);
        string content = $"{joon.ToString()}\n{pool.ToString()}\n{lines[2].ToString()}\n{lines[3].ToString()}\n{lines[4].ToString()}\n{lines[5].ToString()}\n{lines[6].ToString()}\n{khanjar_lvl.ToString()}\n{lines[8].ToString()}\n{lines[9].ToString()}";
        File.WriteAllText(path, content);
        get_and_update_data();

        menu_ask_khanjar.SetActive(false);
    }

    public void ask_khanjar_box_no()
    {
        menu_ask_khanjar.SetActive(false);
    }

    public void show_ask_khanjar()
    {
        if ((pool >= (khanjar_lvl * 5)) && khanjar_lvl < 5)
        {
            menu_ask_khanjar.SetActive(true);

            ask_box_khanjar_lvl.text = (khanjar_lvl + 1).ToString();
            ask_box_khanjar_pool.text = (((khanjar_lvl) * 5) + 5).ToString();
        }
    }

    //-------------ask_zoor---------------
    public void ask_zoor_box_yes()
    {
        pool -= (zoor_lvl + 1) * 5;
        zoor_lvl++;

        string path = Path.Combine(Application.persistentDataPath, "data.csv");
        string[] lines = File.ReadAllLines(path);
        string content = $"{joon.ToString()}\n{pool.ToString()}\n{lines[2].ToString()}\n{lines[3].ToString()}\n{lines[4].ToString()}\n{lines[5].ToString()}\n{lines[6].ToString()}\n{lines[7].ToString()}\n{zoor_lvl.ToString()}\n{lines[9].ToString()}";
        File.WriteAllText(path, content);
        get_and_update_data();

        menu_ask_zoor.SetActive(false);
    }

    public void ask_zoor_box_no()
    {
        menu_ask_zoor.SetActive(false);
    }

    public void show_ask_zoor()
    {
        if ((pool >= (zoor_lvl * 5)) && zoor_lvl < 5)
        {
            menu_ask_zoor.SetActive(true);

            ask_box_zoor_lvl.text = (zoor_lvl + 1).ToString();
            ask_box_zoor_pool.text = (((zoor_lvl) * 5) + 5).ToString();
        }
    }

    //------------ask_gorz----------------
    public void ask_gorz_box_yes()
    {
        pool -= (gorz_lvl + 1) * 5;
        gorz_lvl++;

        string path = Path.Combine(Application.persistentDataPath, "data.csv");
        string[] lines = File.ReadAllLines(path);
        string content = $"{joon.ToString()}\n{pool.ToString()}\n{lines[2].ToString()}\n{lines[3].ToString()}\n{lines[4].ToString()}\n{lines[5].ToString()}\n{lines[6].ToString()}\n{lines[7].ToString()}\n{lines[8].ToString()}\n{gorz_lvl.ToString()}";
        File.WriteAllText(path, content);
        get_and_update_data();

        menu_ask_gorz.SetActive(false);
    }

    public void ask_gorz_box_no()
    {
        menu_ask_gorz.SetActive(false);
    }

    public void show_ask_gorz()
    {
        if ((pool >= (gorz_lvl * 5)) && gorz_lvl < 5)
        {
            menu_ask_gorz.SetActive(true);

            ask_box_gorz_lvl.text = (gorz_lvl + 1).ToString();
            ask_box_gorz_pool.text = (((gorz_lvl) * 5) + 5).ToString();
        }
    }
}
