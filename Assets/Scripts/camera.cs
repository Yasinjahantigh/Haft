using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform characterTransform;

    //public float offesty;
    //float lastposx;
    //public Transform farbackground, middlebackground;
    //private void Start()
    //{
    //    lastposx = transform.position.x;    
    //}

    void Update()
    {
        transform.position = new Vector3(characterTransform.position.x,transform.position.y, transform.position.z);

        //float amounttomovex = transform.position.x - lastposx;
        //farbackground.position = farbackground.position + new Vector3(amounttomovex, 0f, 0f);
        //middlebackground.position += new Vector3(amounttomovex * 0.5f, 0f, 0f);
        //lastposx = transform.position.x;
    }
}



