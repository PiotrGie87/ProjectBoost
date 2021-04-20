using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float MainThrust = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Press Space");
            rb.AddRelativeForce(Vector3.up* MainThrust * Time.deltaTime);
        }
        

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("You want to turn left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("You want to turn right");
        }
    }
}
