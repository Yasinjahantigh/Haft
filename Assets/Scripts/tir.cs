using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class tir : MonoBehaviour
{
    public int speed;
    float local_x;
    float local_y;
    float local_z;
    // Start is called before the first frame update
    void Start()
    {
        local_x = transform.localScale.x;
        local_y = transform.localScale.y;
        local_z = transform.localScale.z;

        if (transform.position.z < -8)
        {
            transform.localScale = new Vector3(-local_x, local_y, local_z);
            speed = -speed;
            //print("byeeeeeeeeeeee");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rostam" || collision.gameObject.tag == "ground")
        {
            Destroy(this.gameObject);
        }
        //Destroy(this.gameObject);

    }

}
