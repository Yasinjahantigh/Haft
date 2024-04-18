using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class rostamtest : MonoBehaviour
{
    public int speed;
    public int jump;
    public bool ishiting;
    // public Animation partab;
    //public bool istiring;
    public AudioClip audiojump;
    public bool iser;
    Rigidbody2D myrig;
    Animator animator;
    AudioSource audioSource;
    public bool ground;
    public bool jump1;
    public bool jump2;
    public GameObject menu;
    public bool isgo_right;
    public bool isgo_left;
    public bool isgo;
    public bool isjump;
    public bool move = true;
    Animation anim;
    public GameObject menuwin;
    float local_x;
    public GameObject bullet;
    public Transform arrotransform;
    bool can_hit = true;
    bool can_tir = true;
    // Start is called before the first frame update
    void Start()
    {
        myrig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
        local_x = transform.localScale.x;



    }





    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //if (transform.rotation.z <=10 && transform.rotation.z <= -10)
        //if (transform.rotation.z > 


        if (transform.position.y < -6.7f)
        {
            menu.SetActive(true);
            Destroy(gameObject);
            move = false;
        }
        //if (Input.GetKey(KeyCode.W)) {
        //    animator.Play("charkhan");
        //}
        if (Input.GetKey(KeyCode.E) && can_hit == true)
        {
            can_hit = false;
            //animator.SetBool("ishit", true);
            animator.Play("hti");
            Invoke("set_can_hit", 1);
        }
        if (stateInfo.IsName("hti"))
        {
            ishiting = true;
        }
        else
        {
            ishiting = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && can_tir == true)
        {
            can_tir = false;
            animator.Play("tir");
            //partab.Play();
            //double ttt = 55 / 60;
            Invoke("partabkhangar", 5 / 6f);
            Invoke("set_can_tir", 5 / 6f);
            //GameObject bulletclone = Instantiate(bullet, arrotransform.position, arrotransform.rotation);
        }


        if (can_tir == true && can_hit == true)
        {
            if (isgo_right == true)
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }

            if (Input.GetKey(KeyCode.RightArrow) || isgo_right == true)
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }

            if (isgo_left == true)
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(-local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || isgo_left == true)
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(-local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }

            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && isgo == false)
            {
                animator.SetBool("isrun", false);
            }


            if (Input.GetKeyDown(KeyCode.Space) && jump2 == false)
            {
                if (jump1 == true)
                {
                    jump2 = true;
                }
                myrig.velocity = new Vector2(myrig.velocity.x, jump);
                //animator.SetBool("jump", true);
                animator.Play("jump");
                audioSource.PlayOneShot(audiojump);
            }
            //if (!Input.GetKeyDown(KeyCode.Space) || isjump == false)
            //{
            //    //animator.SetBool("jump", false);
            //    //animator.Play("jump");
            //}
            //isjump = false;

        }

    }
    //float GetAnimationLength(string clipName)
    //{
    //    AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
    //    foreach (AnimationClip clip in clips)
    //    {
    //        if (clip.name == clipName)
    //        {
    //            return clip.length;
    //        }
    //    }
    //    return 0f;
    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
            jump1 = false;
            jump2 = false;
            // myrig.gravityScale = 0;
            //Destroy(gameObject);

        }

        if (collision.gameObject.tag == "enemy")
        {
            menu.SetActive(true);
            Destroy(gameObject);
            move = false;
            animator.SetBool("isrun", true);
            iser = true;
        }



    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = false;
            jump1 = true;
            //myrig.gravityScale = 6;
            iser = false;

        }

    }

    void OnTriggerEnter2D(Collider2D tagsplayer)
    {
        if (tagsplayer.tag == "win")
        {
            menuwin.SetActive(true);
            Destroy(gameObject);

        }
        if (tagsplayer.gameObject.tag == "neize")
        {
            Destroy(this.gameObject);
        }
        if (tagsplayer.gameObject.tag == "tir")
        {
            Destroy(this.gameObject);
        }

    }
    void partabkhangar()
    {
        if (transform.localScale.x < 0)
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
    void set_can_hit()
    {
        can_hit = true;
    }










    public void set_goright_true()
    {
        isgo_right = true;
        isgo = true;
    }
    public void set_goleft_true()
    {
        isgo_left = true;
        isgo = true;
    }
    public void set_goright_false()
    {
        isgo_right = false;
        isgo = false;
    }
    public void set_goleft_false()
    {
        isgo_left = false;
        isgo = false;
    }
    public void set_jump_true()
    {
        isjump = true;
    }
    public void set_jump_false()
    {
        isjump = false;
    }

}