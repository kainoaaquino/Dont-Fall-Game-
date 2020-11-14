using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public bool cubeGrounded = true; 

    void Start()
    {
        moveSpeed = 7f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);


        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);



        if (Input.GetButtonDown("Jump") && cubeGrounded)
        {
            rb.AddForce(new Vector3(0, 8, 0), ForceMode.Impulse);
            cubeGrounded = false; 
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            cubeGrounded = true; 
        }
    }
}
