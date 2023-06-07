using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 8f;
    public float jumpforce = 8f;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor;
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
          spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
    }


    // Update is called once per frame
    void Update()
    {
           horizontal = Input.GetAxis("Horizontal");


        if(horizontal < 0)


        {
            spriteRenderer.flipX = true;
        }


        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }


        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }


     void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }


     




}
