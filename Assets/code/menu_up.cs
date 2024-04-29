using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class menu_up : MonoBehaviour
{
    public int joon, pool;
    public TMP_Text textMesh_joon, textMesh_pool;
    // Start is called before the first frame update
    void Start()
    {
        string[] lines = File.ReadAllLines("Assets\\code\\data.csv");

        int joon = int.Parse(lines[0]);
        int pool = int.Parse(lines[1]);
        
        print(joon);
        textMesh_joon.text = joon.ToString();
        print(pool);
        textMesh_pool.text = pool.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joon == 0)
        {
            print("bakhti");
        }
    }

    void marg()
    {
        joon--;
    }

    void jayeze()
    {
        int n = 100;
        pool += n;
    }



    
}