using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class rostam_code : MonoBehaviour
{
    int health = 3;
    public int speed;
    public int jump;
    public bool ishiting;
    public AudioClip audiojump;
    public bool iser;
    Rigidbody2D myrig;
    Animator animator;
    AudioSource audioSource;
    public bool ground;
    public bool jump1;
    public bool jump2;
    public bool isgo_right;
    public bool isgo_left;
    public bool isgo;
    public bool isjump;
    public bool move = true;
    public int lose_height;
    Animation anim;
    public GameObject menuwin;
    public GameObject menulose;
  //  public GameObject button;
    float local_x;
    public GameObject bullet;
    public Transform arrotransform;
    public bool can_hit= true;
    bool can_tir = true;
    bool can_charkh = true;
    public bool is_charkh;
    public bool hit;
    bool charkh;
    bool partab;
    public GameObject tir_button_black;
    public GameObject charkh_button_black;
    public GameObject hit_button_black;
    Transform portal;
    Vector3 popo;
   // Image im;


    void Start()
    {
        portal = transform;
        //portal.position = 
        popo = new Vector3(transform.position.x,transform.position.y,transform.position.z);

        myrig = GetComponent<Rigidbody2D>();
        //im = button.GetComponent<Image>();   
        animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
        local_x=transform.localScale.x;
        menuwin.SetActive(false);
        menulose.SetActive(false);
        //button.GetComponent<Image>().fillAmount = 0.2f;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (can_hit == false)
        {
            hit_button_black.SetActive(true);
        }
        else
        {
            hit_button_black.SetActive(false);
        }
        if (can_charkh == false)
        {
            charkh_button_black.SetActive(true);
        }
        else
        {
            charkh_button_black.SetActive(false);
        }
        if (can_tir == false)
        {
            tir_button_black.SetActive(true);
        }
        else
        {
            tir_button_black.SetActive(false);
        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //if (transform.rotation.z <=10 && transform.rotation.z <= -10)
        //if (transform.rotation.z > 


        if (transform.position.y < lose_height)
        {
            //menulose.SetActive(true);
            //Destroy(gameObject);
            health--;
            //transform.position = new Vector3(-50f, 0f, 0f);
            if (health == 0)
            {
                //menulose.SetActive(true);

                Destroy(this.gameObject);
            }
            else
            {
                transform.position = popo;
            }
        }
        if (Input.GetKey(KeyCode.W) || charkh==true && can_charkh == true)
        {
            animator.Play("charkhan");
            can_charkh = false;
            Invoke("set_can_charkh", 7);

        }
        if (stateInfo.IsName("charkhan"))
        {
            is_charkh = true;
        }
        else
        {
            is_charkh = false;
        }

        if (Input.GetKey(KeyCode.E) || hit == true && can_hit == true)
        {
            can_hit = false;
            //animator.SetBool("ishit", true);
            animator.Play("hti");
            Invoke("set_can_hit", 1);
        }
        if (stateInfo.IsName("hti"))
        {
            ishiting=true;
        }
        else
        {
            ishiting=false;
        }

        if (Input.GetKeyDown(KeyCode.R) || partab == true && can_tir == true)
        {
            can_tir=false;
            animator.Play("tir");
            Invoke("partabkhangar", 5/6f);
            Invoke("set_can_tir", 5 / 6f);
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


            if (Input.GetKeyDown(KeyCode.Space) || isjump == true && jump2 == false)
            {
                if (jump1 == true)
                {
                    jump2 = true;
                }
                myrig.velocity = new Vector2(myrig.velocity.x, jump);
                animator.Play("jump");
                audioSource.PlayOneShot(audiojump);
            }
            
            isjump= false;

        }
        charkh = false;
        hit = false;
        partab = false;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
            jump1 = false;
            jump2 = false;
        }

        if (collision.gameObject.tag == "enemy")
        {
            health--;
            if (health == 0)
            {
                //menulose.SetActive(true);
                Destroy(gameObject);
                move = false;
                animator.SetBool("isrun", true);
                iser = true;
            }
            else
            {
                transform.position = popo;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = false;
            jump1 = true;
            iser = false;
        }
    }

    void OnTriggerEnter2D(Collider2D tagsplayer)
    {
        if (tagsplayer.gameObject.tag == "portal")
        {
            popo = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        }
        if (tagsplayer.gameObject.tag == "win_object")
        {
            string userName = Environment.UserName;

            print("win");
            string text = File.ReadAllText("C:\\Users\\"+userName+"\\Documents\\7\\data.csv");
            string[] lines = text.Split('\n');
            int num = int.Parse(lines[0]);
            print("num:");
            print(num);
            if (num == (SceneManager.GetActiveScene().buildIndex) - 1)
            {
                num = num + 1;
            }
            File.WriteAllText("C:\\Users\\"+userName+"\\Documents\\7\\data.csv", num.ToString());
            menuwin.SetActive(true);
            Destroy(this.gameObject);
        }
        if (tagsplayer.gameObject.tag == "neize" && is_charkh == false)
        {
            //menulose.SetActive(true);
            // Destroy(this.gameObject);
            health--;
            if (health == 0)
            {
               // menulose.SetActive(true);
                Destroy(gameObject);
                move = false;
                animator.SetBool("isrun", true);
                iser = true;
            }
            else
            {
                transform.position = popo;
            }
        }
        if (tagsplayer.gameObject.tag == "tir" && is_charkh == false)
        {
            //menulose.SetActive(true);
            //Destroy(this.gameObject);
            health--;
            if (health == 0)
            {
                //menulose.SetActive(true);
                Destroy(gameObject);
                move = false;
                animator.SetBool("isrun", true);
                iser = true;
            }
            else
            {
                transform.position = popo;
            }
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
    void set_can_charkh()
    {
        can_charkh = true;
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
    public void set_hit_true()
    {
        hit=true;
    }
    public void set_partab_true()
    {
        partab = true;
    }
    public void set_charkh_true()
    {
        charkh = true;
    }
    //public void set_jump_false()
    //{
    //    isjump = false;
    //}

}