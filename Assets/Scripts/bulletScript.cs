using UnityEngine;
using System.Collections;

public class bulletScript: MonoBehaviour {

	public float speed;

	public void velocity(Transform _transform)
    {
        GetComponent<Rigidbody2D>().velocity = _transform.right * speed;
    }
}
