using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }
}
