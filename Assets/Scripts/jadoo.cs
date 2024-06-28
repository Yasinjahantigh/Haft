using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class jadoo : MonoBehaviour
{
    public bool do_on_X = true;
    public float speed;
    public float X1;
    public float X2;
    public float Y1;
    public float Y2;
    bool walk_right = true;
    bool walk_up = true;
    float localx;
    float localy;
    // Start is called before the first frame update
    void Start()
    {
        walk_right = true;
        walk_up = true;
        localx = transform.localScale.x;
        localy = transform.localScale.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (do_on_X == true)
        {
            if (transform.position.x > X2)
            {
                walk_right = false;
            }
            else if (transform.position.x < X1)
            {
                walk_right = true;
            }

            if (walk_right)
            {
                transform.Translate(new Vector2(0, -speed * Time.deltaTime));
                
                transform.localScale = new Vector3(transform.localScale.x, localy, transform.localScale.z);
            }
            if(!walk_right) 
            {
                transform.Translate(new Vector2(0, speed * Time.deltaTime));
               
                transform.localScale = new Vector3(transform.localScale.x, -localy, transform.localScale.z);
            }
        }
        else
        {
            if (transform.position.y > Y2)
            {
                walk_up = false;
            }
            else if (transform.position.y < Y1)
            {
                walk_up = true;
            }
            if (walk_up)
            {
                transform.Translate(new Vector2(0, speed * Time.deltaTime));
                transform.localScale = new Vector3(transform.localScale.x, -localy, transform.localScale.z);
            }
            if (!walk_up)
            {
                transform.Translate(new Vector2(0, -speed * Time.deltaTime));
                transform.localScale = new Vector3(transform.localScale.x, localy, transform.localScale.z);
            }
        }
    
    }
}
