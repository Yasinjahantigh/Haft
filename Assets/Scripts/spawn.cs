using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject bullet;
    public Transform arrotransform;
    //public int speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject bulletclone = Instantiate(bullet, arrotransform.position, arrotransform.rotation);
            //while (true)
            //{
            //    bulletclone.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
            //}
        }
    }

}

