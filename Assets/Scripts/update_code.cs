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

        sorat = sorats[sorat_lvl];
        khanjar = khanjars[khanjar_lvl];
        zoor = zoors[zoor_lvl];
        gorz = gorzes[gorz_lvl];

        textMesh_joon.text = joon.ToString();
        textMesh_pool.text = pool.ToString();
        textMesh_sorat.text = sorat_lvl.ToString();
        textMesh_khanjar.text = khanjar_lvl.ToString();
        textMesh_zoor.text = zoor_lvl.ToString();
        textMesh_gorz.text = gorz_lvl.ToString();
    }
    void Start()
    {
        get_and_update_data();
    }

    // Update is called once per frame
    void Update()
    {
        //get_and_update_data(); // #TODO باید حذف بشه، ممکنه کند کنه...
        //string path = Path.Combine(Application.persistentDataPath, "data.csv"); ;

        //string[] lines = File.ReadAllLines(path);
        //int joon = int.Parse(lines[0]);
        //int pool = int.Parse(lines[1]);
        //int sorat = int.Parse(lines[2]);
        //float khanjar = float.Parse(lines[3]);
        //int zoor = int.Parse(lines[4]);
        //int gorz = int.Parse(lines[5]);

        //textMesh_joon.text = joon.ToString();
        //textMesh_pool.text = pool.ToString();
        //textMesh_sorat.text = sorat.ToString();
        //textMesh_khanjar.text = khanjar.ToString();
        //textMesh_zoor.text = zoor.ToString();
        //textMesh_gorz.text = gorz.ToString();
    }

    public void menu_asli()
    {
        SceneManager.LoadScene(0);
    }

    public void update_joon()
    {
        if (UnityEditor.EditorUtility.DisplayDialog("آپدیت جون", $"می‌خوای برای ارتقای جون به {joon + 1}، {joon * 5} سکه بدی؟", "آره!", "نه!"))
        {
            print(0);
            pool -= joon * 5;
            print(1);
            joon++;
            print(2);

            string path = Path.Combine(Application.persistentDataPath, "data.csv");
            print(3);
            string[] lines = File.ReadAllLines(path);
            print(4);
            string content = $"{joon.ToString()}\n{pool.ToString()}\n{lines[2].ToString()}\n{lines[3].ToString()}\n{lines[4].ToString()}\n{lines[5].ToString()}\n{lines[6].ToString()}\n{lines[7].ToString()}\n{lines[8].ToString()}\n{lines[9].ToString()}";
            print(5);
            File.WriteAllText(path, content);
            print(6);
            get_and_update_data();
            print(7);
        }
        else
        {
            print("nakhaast:(");
        }


    }
}
