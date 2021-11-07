using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SC_IRPlayer : MonoBehaviour
{
    public float gravity = 20.0f;
    public float jumpHeight = 2.5f;
    public bool controlsactive = true;
    Rigidbody r;
    bool grounded = false;
    Vector3 defaultScale;
    bool crouch = false;
    [HideInInspector]
    Touch touch;
    bool swipeup;
    bool duck;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        r.freezeRotation = true;
        r.useGravity = false;
        defaultScale = transform.localScale;

    }

    void Update()
    {
        // Jump
        if (controlsactive == true)
        {
            if (Input.GetKeyDown(KeyCode.W) && grounded)
            {
                r.velocity = new Vector3(r.velocity.x, CalculateJumpVerticalSpeed(), r.velocity.z);
            }

            //Crouch
            crouch = Input.GetKey(KeyCode.S);
            if (crouch)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(defaultScale.x, defaultScale.y * 0.4f, defaultScale.z), Time.deltaTime * 7);
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * 7);
            }

            //left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.z <= FindObjectOfType<SC_GroundGenerator>().leftclampgetter().position.z)
                {
                    transform.position = transform.position;
                }
                else { transform.Translate(Vector3.left * 2 * Time.deltaTime); }

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.z >= (FindObjectOfType<SC_GroundGenerator>().rightclampgetter().position.z))
                {
                    transform.position = transform.position;
                }
                else { transform.Translate(Vector3.right * 2 * Time.deltaTime); }
            }
        }
        else { GetComponent<Rigidbody>().useGravity = false; }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 pos;
        
        // We apply gravity manually for more tuning control
        if (controlsactive == true)
        { 
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));

        //grounded = false;
        }

        if(Input.touchCount > 0)
        {
            
            SC_GroundGenerator.instance.gameStarted = true;
            touch = Input.GetTouch(0);
          
            
            if (Input.touchCount == 1)
            {
                pos = touch.position;
                Debug.Log("Pos: " + pos);
                checkforswipes();
                if (controlsactive == true)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                       
                        if (swipeup == true && grounded)
                        {
                            grounded = false;
                            r.velocity = new Vector3(r.velocity.x, CalculateJumpVerticalSpeed(), r.velocity.z);
                            swipeup = false;
                        }
                        else if(duck == true)
                        {
                            crouch = Input.GetKey(KeyCode.S);
                            if (crouch)
                            {
                                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(defaultScale.x, defaultScale.y * 0.4f, defaultScale.z), Time.deltaTime * 7);
                            }
                            else
                            {
                                transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * 7);
                            }
                        }
                    }
                    else if(touch.phase == TouchPhase.Stationary)
                    {
                        if (pos.x > ((Screen.width / 2) + (Screen.width/4)))
                        {
                            if (transform.position.z >= (FindObjectOfType<SC_GroundGenerator>().rightclampgetter().position.z))
                            {
                                transform.position = transform.position;
                            }
                            else { transform.Translate(Vector3.right * 2 * Time.deltaTime); }
                        }
                        else if (pos.x < ((Screen.width / 2) - (Screen.width / 4)))
                        {
                            if (transform.position.z <= FindObjectOfType<SC_GroundGenerator>().leftclampgetter().position.z)
                            {
                                transform.position = transform.position;
                            }
                            else { transform.Translate(Vector3.left * 2 * Time.deltaTime); }
                        }
                    }
                }
                else
                    {
                        GetComponent<Rigidbody>().useGravity = false;
                    }
                
            }
            else
            {
                
            }
        }
    }

    private void checkforswipes()
    {
        Vector3 startswipepos = new Vector3(0,0,0);
        Vector3 endswipepos = new Vector3(0,0,0);
        if (touch.phase == TouchPhase.Began)
        {
            startswipepos = touch.position;
        }
        if(touch.phase == TouchPhase.Ended)
        {
            endswipepos = touch.position;
        }
        if (endswipepos.y - startswipepos.y > 10)
        {
            swipeup = true;
        }
        else if(endswipepos.y - startswipepos.y < -10)
        {
            duck = true;
        }
        
        Debug.Log("Startpos: " + startswipepos);
        Debug.Log("EndPos: " + endswipepos);
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            //print("GameOver!");
            SC_GroundGenerator.instance.gameOver = true;
        }
        else if(collision.gameObject.tag == "Pickup")
        {
            SC_GroundGenerator.instance.Pickup = true;
            FindObjectOfType<M_Narration>().PickupPrint();
        }
    }
}
