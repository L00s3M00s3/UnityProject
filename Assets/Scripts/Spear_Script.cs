using UnityEngine;
using System.Collections;

public class Spear_Script : MonoBehaviour
{

    public float speed;

    public void velocity(Transform _transform,bool right)
    {
        if (right)
        {
            transform.rotation = Quaternion.Euler(transform.forward * 90);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.forward * -90);
        }
        GetComponent<Rigidbody2D>().velocity = _transform.right * speed;
    }
}