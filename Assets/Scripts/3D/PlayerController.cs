using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float charSpeed=1f;
    public float turnSpeed=50f;
    public Rigidbody rb;
    public float jumpForce=5;
    // Update is called once per frame
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward*charSpeed*Time.deltaTime);
        if(Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back*charSpeed*Time.deltaTime);
        if(Input.GetKey(KeyCode.A))
            //transform.Translate(Vector3.down*turnSpeed*Time.deltaTime);
            transform.Translate(Vector3.left*turnSpeed*Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
            //transform.Translate(Vector3.up*turnSpeed*Time.deltaTime);
            transform.Translate(Vector3.right*turnSpeed*Time.deltaTime);

        if(Input.GetKey(KeyCode.Space))
            rb.velocity=new Vector3(0, jumpForce, 0);

        if(Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0){
            float mH=Input.GetAxis("Horizontal");
            float mV=Input.GetAxis("Vertical");
            rb.velocity=new Vector3(mH*charSpeed, rb.velocity.y, mV*charSpeed);
            transform.forward=new Vector3(mH, 0, mV);
        }
    }
}