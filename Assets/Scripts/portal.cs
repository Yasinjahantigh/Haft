using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class portal : MonoBehaviour
{
    Animator animator;
    bool is_on = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D tagsplayer)
    {
        if (tagsplayer.gameObject.tag == "rostam" && is_on == false)
        {
            animator.Play("turn_on");
            is_on = true;

        }
    }
}
