using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_neize : MonoBehaviour
{
    float localx;
    public float X1;
    public float X2;
    public bool walk_right = true;
    public bool walk_left = false;
    public bool run_right = true;
    public bool run_left = false;
    int joon = 2;
    public float speedwalk;
    public float speedrun;
    public GameObject Rostam;
    Animator animator;
    bool tagib;
    rostam_code l;
    

    // Start is called before the first frame update
    void Start()
    {
        l = Rostam.GetComponent<rostam_code>();

        //Rostam.GetComponent<rostam_code>
        localx = transform.localScale.x;
        walk_right = true;
        run_right = true;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (joon == 0)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x > X2)
        {
            run_right = false;
            run_left = true;
            walk_right = false;
            walk_left = true;
        }
        else if (transform.position.x < X1)
        {
            run_right = true;
            run_left = false;
            walk_right = true;
            walk_left = false;
        }

        if (tagib == true)
        {
            if (Rostam.transform.position.x > transform.position.x)
            {
                animator.SetBool("isrun_enemy", true);
                transform.Translate(new Vector2(speedrun * Time.deltaTime, 0));
                transform.localScale = new Vector3(localx, transform.localScale.y, transform.localScale.z);

            }
            else
            {
                animator.SetBool("isrun_enemy", true);
                transform.Translate(new Vector2(-speedrun * Time.deltaTime, 0));
                transform.localScale = new Vector3(-localx, transform.localScale.y, transform.localScale.z);

            }
        }

        if (Rostam.transform.position.x > X1 && Rostam.transform.position.x < X2)
        {
            if (Rostam.transform.position.x < transform.position.x && transform.localScale.x < 0)
            {
                tagib = true;
            }
            if (Rostam.transform.position.x > transform.position.x && transform.localScale.x > 0)
            {
                tagib = true;
            }
            if (tagib == false)
            {
                if (walk_right)
                {
                    animator.SetBool("isrun_enemy", false);
                    transform.Translate(new Vector2(speedwalk * Time.deltaTime, 0));
                    transform.localScale = new Vector3(localx, transform.localScale.y, transform.localScale.z);

                }
                else if (walk_left)
                {
                    animator.SetBool("isrun_enemy", false);
                    transform.Translate(new Vector2(-speedwalk * Time.deltaTime, 0));
                    transform.localScale = new Vector3(-localx, transform.localScale.y, transform.localScale.z);

                }
            }

        }
        else
        {
            tagib = false;
            if (walk_right)
            {
                animator.SetBool("isrun_enemy", false);
                transform.Translate(new Vector2(speedwalk * Time.deltaTime, 0));
                transform.localScale = new Vector3(localx, transform.localScale.y, transform.localScale.z);

            }
            else if (walk_left)
            {
                animator.SetBool("isrun_enemy", false);
                transform.Translate(new Vector2(-speedwalk * Time.deltaTime, 0));
                transform.localScale = new Vector3(-localx, transform.localScale.y, transform.localScale.z);

            }
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rostam" && l.is_charkh == true)
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "rostam")
        {
            tagib = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "khangar")
        {
            joon = joon - 1;

        }
        if (collision.gameObject.tag == "gorz" && l.ishiting == true)
        {
            Destroy(this.gameObject);

        }


    }
}
