using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform characterTransform;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(characterTransform.position.x, characterTransform.position.y, transform.position.z);
    }
}



