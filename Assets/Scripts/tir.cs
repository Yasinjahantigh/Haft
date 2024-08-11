using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class tir : MonoBehaviour
{
    public int speed;
    public int time_to_destroy;
    float local_x;
    float local_y;
    float local_z;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("nabood", time_to_destroy);
        local_x = transform.localScale.x;
        local_y = transform.localScale.y;
        local_z = transform.localScale.z;

        if (transform.position.z < -8)
        {
            transform.localScale = new Vector3(-local_x, local_y, local_z);
            speed = -speed;
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
    public void nabood()
    {
        Destroy(gameObject);
    }

}
