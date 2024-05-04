using UnityEngine;

public class tig_chatkhan : MonoBehaviour
{
    public int speed;
    void Update()
    {
        //transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        transform.Rotate(new Vector3(0,0,speed * Time.deltaTime));
    }
}
