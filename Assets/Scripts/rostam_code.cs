using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.UIElements;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;


public class rostam_code : MonoBehaviour
{
    int joon ;
    int pool;
    public int speed;
    public float speedhit;
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
    float local_x;
    public GameObject bullet;
    public Transform arrotransform;
    public bool can_hit= true;
    bool can_tir = true;
    bool can_charkh = true;
    bool can_get_pool = true;
    bool can_die = true;
    public bool is_charkh;
    public bool hit;
    bool charkh;
    bool partab;
    public GameObject tir_button_black;
    public GameObject charkh_button_black;
    public GameObject hit_button_black;
    Transform portal;
    Vector3 popo;
    public TMP_Text textMesh_joon, textMesh_pool;
    bool canrun = true;


    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "data.csv");

        string[] lines = File.ReadAllLines(path);
        joon = int.Parse(lines[0]);
        pool = int.Parse(lines[1]);
        print(joon);
        textMesh_joon.text = joon.ToString();
        print(pool);
        textMesh_pool.text = pool.ToString();
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
        //string[] lines = File.ReadAllLines("Assets\\Scripts\\data.csv");
        //joon = int.Parse(lines[0]);
        //pool = int.Parse(lines[1]);
        //print(joon);
        //textMesh_joon.text = joon.ToString();
        //print(pool);
        //textMesh_pool.text = pool.ToString();
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
            can_die = false;
            Invoke("set_can_die", 1);
            joon--;
            textMesh_joon.text = joon.ToString();
            //transform.position = new Vector3(-50f, 0f, 0f);
            if (joon == 0)
            {
                menulose.SetActive(true);
                // Destroy(gameObject);
                move = false;
                animator.SetBool("isrun", true);
                iser = true;
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
            animator.Play("hit3");
            Invoke("set_can_hit", 1);
        }
        if (stateInfo.IsName("hit3"))
        {
            ishiting=true;
            if (transform.localScale.x > 0)
            {
                transform.Translate(new Vector2(speedhit * Time.deltaTime, 0));
            }
            else
            {
                transform.Translate(new Vector2(-speedhit * Time.deltaTime, 0));
            }
        }
        else
        {
            ishiting=false;
        }

        if (Input.GetKeyDown(KeyCode.R) || partab == true && can_tir == true)
        {
            //audioSource.PlayOneShot(audiojump);
            can_tir =false;
            animator.Play("tir");
            Invoke("partabkhangar", 5/6f);
            Invoke("set_can_tir", 5 / 6f);
        }


        if (can_tir == true && can_hit == true)
        {
            if (isgo_right == true && canrun)
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }

            if (Input.GetKey(KeyCode.RightArrow) && canrun || isgo_right == true && canrun)
            {
                transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }

            if (isgo_left == true && canrun)
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(-local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && canrun || isgo_left == true && canrun)
            {
                transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                transform.localScale = new Vector3(-local_x, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isrun", true);
            }

            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && isgo == false)
            {
                animator.SetBool("isrun", false);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                canrun = false;
                if (jump2 == false)
                {
                    //ground = false;
                    if (jump1 == false)
                    {
                        jump1 = true;
                    }
                    else
                    {
                        jump2 = true;
                    }
                    myrig.velocity = new Vector2(myrig.velocity.x, jump);
                    animator.Play("jump");
                    audioSource.PlayOneShot(audiojump);   
                }
                canrun = true;
            }

            

        }
        charkh = false;
        hit = false;
        partab = false;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            //ground = true;
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (!stateInfo.IsName("jump"))
            {
                jump1 = false;
                jump2 = false;
            }
        }

        //if (collision.gameObject.tag == "enemy")
        //{
        //    joon--;
        //    if (joon == 0)
        //    {
        //        //menulose.SetActive(true);
        //        Destroy(gameObject);
        //        move = false;
        //        animator.SetBool("isrun", true);
        //        iser = true;
        //    }
        //    else
        //    {
        //        transform.position = popo;
        //    }
        //}
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "ground")
        //{
        //    ground = false;
        //    jump1 = true;
        //    iser = false;
        //}
    }

    void OnTriggerEnter2D(Collider2D tagsplayer)
    {

        if (tagsplayer.gameObject.tag == "portal")
        {
            popo = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        }

        if (tagsplayer.gameObject.tag == "win_object")
        {
            string path = Path.Combine(Application.persistentDataPath, "data_game.csv");
            string[] lines = File.ReadAllLines(path);
            int num = int.Parse(lines[0]);

            print("num:");
            print(num);
            if (num == (SceneManager.GetActiveScene().buildIndex))
            {
                num = num + 1;
            }
            File.WriteAllText(path, num.ToString());
            // File.WriteAllText("C:\\Users\\"+userName+"\\Documents\\7\\data.csv", num.ToString());
            menuwin.SetActive(true);
        }

        if (tagsplayer.gameObject.tag == "neize" && is_charkh == false && can_die)
        {
            //menulose.SetActive(true);
            // Destroy(this.gameObject);
            can_die = false;
            Invoke("set_can_die", 1);
            transform.position = popo;
            joon--;
            textMesh_joon.text = joon.ToString();
            if (joon == 0)
            {
                menulose.SetActive(true);
                // Destroy(gameObject);
                move = false;
                animator.SetBool("isrun", true);
                iser = true;
            }
            else
            {
                transform.position = popo;
            }
        }

        if (tagsplayer.gameObject.tag == "tir" && is_charkh == false && can_die)
        {
            //menulose.SetActive(true);
            //Destroy(this.gameObject);
            can_die = false;
            Invoke("set_can_die", 1);
            joon--;
            textMesh_joon.text = joon.ToString();
            if (joon == 0)
            {
                menulose.SetActive(true);
                // Destroy(gameObject);
                move = false;
                animator.SetBool("isrun", true);
                iser = true;
            }
            else
            {
                transform.position = popo;
            }
        }
        if (tagsplayer.gameObject.tag == "jadoo" && can_die)
        {
            can_die = false;
            Invoke("set_can_die", 1);
            transform.position = popo;
            joon--;
            textMesh_joon.text = joon.ToString();
            if (joon == 0)
            {
                menulose.SetActive(true);
                // Destroy(gameObject);
                move = false;
                animator.SetBool("isrun", true);
                iser = true;
            }
            else
            {
                transform.position = popo;
            }
        }
        
        if (tagsplayer.gameObject.tag == "pool" && can_get_pool)
        {
            Invoke("set_can_pool", 0.1f);
            can_get_pool = false;
            Destroy(tagsplayer.gameObject);
            pool++;        
            textMesh_pool.text = pool.ToString();
            string path = Path.Combine(Application.persistentDataPath, "data.csv");

        string[] lines = File.ReadAllLines(path);
            lines[1] = pool.ToString();
            File.WriteAllLines(path, lines);
        }
        if (tagsplayer.gameObject.tag == "tig" && can_die)
        {
            can_die = false;
            Invoke("set_can_die", 1);
            joon--;
            textMesh_joon.text = joon.ToString();
            if (joon == 0)
            {
                menulose.SetActive(true);
                // Destroy(gameObject);
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
        if (jump2 == false)
        {
            ground = false;
            if (jump1 == false)
            {
                jump1 = true;
            }
            else
            {
                jump2 = true;
            }
            myrig.velocity = new Vector2(myrig.velocity.x, jump);
            animator.Play("jump");
            audioSource.PlayOneShot(audiojump);
        }
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
    public void set_can_pool()
    {
        can_get_pool = true;
    }
    public void set_can_die()
    {
        can_die = true;
    }
}