using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khangar : MonoBehaviour
{
    public int time_to_destroy;
    public int speed;
    //private GameObject rostam;

    void Start()
    {
        Invoke("nabood" ,time_to_destroy);
        if (transform.position.z < -8)
        {
            transform.localScale = new Vector3(0.4259533f, 0.4259533f, 1);
            speed = -speed;
        }
    }
    void Update()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);  
    }
    public void nabood()
    {
        Destroy(gameObject);
    }
}

