using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorShuffle : Overlap_Generic {
    
    public bool rightFacing;
    public bool shinning;
    [HideInInspector]
    public Vector3 origin;
    public GameObject encountered;
    float coolDown = 1.0f;
    const float buffer = 1.0f;
    public RaycastHit2D hit;
    LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, gameObject.transform.position);
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        if (rightFacing)
        {
            transform.Rotate(-Vector3.forward, 90.0f);
        }
        
    }

	// Update is called once per frame
	void Update () {
        if (overlap)
        {
            switchMirror();
        }
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        if (shinning)
        {
            debugReflection(origin);
            if (hit)
            {
                if (hit.collider.tag == "Mirror")
                {
                    hit.collider.gameObject.GetComponent<MirrorShuffle>().shinning = true;
                    hit.collider.gameObject.GetComponent<MirrorShuffle>().origin = gameObject.transform.position;
                    encountered = hit.collider.gameObject;
                    line.SetPosition(1, hit.collider.gameObject.transform.position);
                }
                if(hit.collider.tag == "Plant")
                {
                    Debug.Log("Plant Growing");
                }
            }
            else
            {

                Debug.Log(gameObject.name + "isn't hitting anything");
                if (encountered != null)
                {
                    
                    encountered.GetComponent<MirrorShuffle>().shinning = false;
                }
            }
        }
        else
        {
            if (encountered != null)
            {
                encountered.GetComponent<MirrorShuffle>().shinning = false;
            }
            line.SetPosition(1, gameObject.transform.position);
        }
        
	}

   

    void switchMirror()
    {
        if (coolDown <= 0)
        {
            if (rightFacing)
            {
                transform.Rotate(Vector3.forward, 90.0f);
                coolDown = 1.0f;
                rightFacing = false;
            }
            else
            {
                transform.Rotate(-Vector3.forward, 90.0f);
                coolDown = 1.0f;
                rightFacing = true; ;
            }
            
        }
    }

    

    void debugReflection(Vector3 position)
    {
        
            
            Debug.Log("Emmiter Madnitude: " + position.magnitude);
            Debug.Log("Reflector Magnitude: " + gameObject.transform.position.magnitude);
            if (Mathf.Abs(position.magnitude) > Mathf.Abs(gameObject.transform.position.magnitude))
            {
                if (position.y > gameObject.transform.position.y)
                {
                    if (rightFacing)
                    {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x + buffer, transform.position.y), Vector2.right, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + Vector3.right*5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.right, Color.red);
                    }
                    else {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x - buffer, transform.position.y), Vector2.left, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + Vector3.left * 5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.left, Color.red);
                    }
                }
                else
                {
                    if (rightFacing)
                    {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + buffer), Vector2.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + Vector3.up * 5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.up, Color.red);
                    }
                    else
                    {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - buffer), -Vector2.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + -Vector3.up * 5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.down, Color.red);
                    }

                }
            }
            else
            {
                if (position.y < gameObject.transform.position.y)
                {
                    if (rightFacing)
                    {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x - buffer, transform.position.y), Vector2.left, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + Vector3.left * 5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.left, Color.red);
                    }
                    else {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x + buffer, transform.position.y), Vector2.right, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + Vector3.right * 5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.right, Color.red);
                    }
                }
                else {
                    if (rightFacing)
                    {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - buffer), -Vector2.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + -Vector3.up * 5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.down, Color.red);
                    }
                    else
                    {
                        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + buffer), Vector2.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("Mirror"));
                    line.SetPosition(1, gameObject.transform.position + Vector3.up * 5);
                    Debug.DrawRay(gameObject.transform.position, Vector2.up, Color.red);
                    }
                }
            }
        }
    }

