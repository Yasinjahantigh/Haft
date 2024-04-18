using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_kaman : MonoBehaviour
{
    float localx;
    public float X1;
    public float X2;
    public bool walk_right = true;
    public bool walk_left = false;
    int joon = 2;
    public float speed;
    public GameObject Rostam;
    Animator animator;
    public GameObject bullet;
    public Transform arrotransform;
    bool can_tir = true;
    rostam_code l;
    // Start is called before the first frame update
    void Start()
    {
        l = Rostam.GetComponent<rostam_code>();
        localx = transform.localScale.x;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (joon == 0)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x > X2)
        {
            walk_right = false;
            walk_left = true;
        }
        else if (transform.position.x < X1)
        {
            walk_right = true;
            walk_left = false;
        }

        if (Rostam.transform.position.x > X1 && Rostam.transform.position.x < X2)
        {
            if (Rostam.transform.position.x < transform.position.x)
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-localx, transform.localScale.y, transform.localScale.z);
                }
                if (can_tir == true)
                {
                    can_tir = false;
                    animator.Play("tir_enemy_kaman");
                    Invoke("partab_tir", 77 / 60);
                    Invoke("set_can_tir", 2);
                }
            }
            if (Rostam.transform.position.x > transform.position.x)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(localx, transform.localScale.y, transform.localScale.z);
                }
                if (can_tir == true)
                {
                    can_tir = false;
                    animator.Play("tir_enemy_kaman");
                    Invoke("partab_tir", 77 / 60);
                    Invoke("set_can_tir", 2);
                }
            }
        }

        else
        {
            if (!stateInfo.IsName("tir_enemy_kaman"))
            {
                if (walk_right)
                {
                    //animator.SetBool("isrun_enemy", false);
                    transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                    transform.localScale = new Vector3(localx, transform.localScale.y, transform.localScale.z);

                }
                else if (walk_left)
                {
                    //animator.SetBool("isrun_enemy", false);
                    transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                    transform.localScale = new Vector3(-localx, transform.localScale.y, transform.localScale.z);

                }
            }
        }
    }
    //void partab_tir_left()
    //{

    //    Vector3 newposition = arrotransform.position;
    //    newposition.z = -9;
    //    arrotransform.position = newposition;

    //    Vector3 newRotation = arrotransform.rotation.eulerAngles;
    //    newRotation.z = 1;
    //    arrotransform.rotation = Quaternion.Euler(newRotation);
    //    GameObject bulletclone = Instantiate(bullet, arrotransform.position, arrotransform.rotation);

    //}
    //void partab_tir_right()
    //{
    //    Vector3 newRotation = arrotransform.rotation.eulerAngles;
    //    newRotation.z = 1;
    //    arrotransform.rotation = Quaternion.Euler(newRotation);
    //    GameObject bulletclone = Instantiate(bullet, arrotransform.position, arrotransform.rotation);
    //}
    void partab_tir()
    {
        if (Rostam.transform.position.x < transform.position.x)
        {
            Vector3 newposition = arrotransform.position;
            newposition.z = -9;
            arrotransform.position = newposition;
        }

        Vector3 newRotation = arrotransform.rotation.eulerAngles;
        newRotation.z = 1;
        arrotransform.rotation = Quaternion.Euler(newRotation);
        GameObject bulletclone = Instantiate(bullet, arrotransform.position, arrotransform.rotation);

    }
    void set_can_tir()
    {
        can_tir = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rostam" && l.is_charkh == true)
        {
            Destroy(this.gameObject);

        }
    }
        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "khangar" )
        {
            joon = joon - 1;

        }
        if (collision.gameObject.tag == "gorz" && l.ishiting==true)
        {
            Destroy(this.gameObject);

        }


    }
}
