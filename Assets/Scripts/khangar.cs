using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khangar : MonoBehaviour
{
    public int speed;
    //private GameObject rostam;

    void Start()
    {
        //Vector3 newposition = transform.position;
        //newposition.z = -1000;
        //transform.position = newposition;
        //print(transform.position.z);
        if (transform.position.z < -8)
        {
            transform.localScale = new Vector3(0.4259533f, 0.4259533f, 1);
            speed = -speed;
            //print("byeeeeeeeeeeee");
        }

        //rostam = GameObject.FindWithTag("rostam");
        //if (rostam.transform.localScale.x > 0)
        //{
        //    transform.localScale = new Vector3(-0.4259533f, 0.4259533f, 1);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(0.4259533f, 0.4259533f, 1);
        //    speed = -speed;
        //}
    }
    void Update()
    {
        //BoxCollider2D b = gameObject.GetComponent<BoxCollider2D>();
        //b.isTrigger = false;
        //b.size = new Vector3(0.3660428f, 0.5360068f, 0.1f);

        transform.Translate(new Vector2(speed * Time.deltaTime, 0));

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    // نابود کردن گیم‌اوبجکت
    //    Destroy(gameObject);
    //}
}

