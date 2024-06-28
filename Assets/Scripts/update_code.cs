using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;


public class update_code : MonoBehaviour
{
    public TMP_Text textMesh_joon, textMesh_pool, textMesh_sorat, textMesh_khanjar, textMesh_zoor, textMesh_gorz;
    // Start is called before the first frame update
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.csv"); ;

        string[] lines = File.ReadAllLines(path);
        int joon = int.Parse(lines[0]);
        int pool = int.Parse(lines[1]);
        int sorat = int.Parse(lines[2]);
        int khanjar = int.Parse(lines[3]);
        int zoor = int.Parse(lines[4]);
        int gorz = int.Parse(lines[5]);

        textMesh_joon.text = joon.ToString();
        textMesh_pool.text = pool.ToString();
        textMesh_sorat.text = sorat.ToString();
        textMesh_khanjar.text = khanjar.ToString();
        textMesh_zoor.text = zoor.ToString();
        textMesh_gorz.text = gorz.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.csv"); ;

        string[] lines = File.ReadAllLines(path);
        int joon = int.Parse(lines[0]);
        int pool = int.Parse(lines[1]);
        int sorat = int.Parse(lines[2]);
        int khanjar = int.Parse(lines[3]);
        int zoor = int.Parse(lines[4]);
        int gorz = int.Parse(lines[5]);

        textMesh_joon.text = joon.ToString();
        textMesh_pool.text = pool.ToString();
        textMesh_sorat.text = sorat.ToString();
        textMesh_khanjar.text = khanjar.ToString();
        textMesh_zoor.text = zoor.ToString();
        textMesh_gorz.text = gorz.ToString();
    }

    public void menu_asli()
    {
        SceneManager.LoadScene(0);
    }

}
