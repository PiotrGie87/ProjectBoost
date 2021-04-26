using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement :MonoBehaviour 
{
    Rigidbody rb;
    AudioSource audio;
    [SerializeField] float mainThrust = 0f;
    [SerializeField] float turningSpeed = 0f;
    [SerializeField] float sideThrust = 0f;
    [SerializeField] AudioClip thrust;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        LeftThrust();
        RightThrust();
    }

    void ProcessThrust()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            
            rb.AddRelativeForce(Vector3.up* mainThrust * Time.deltaTime);

            if (!audio.isPlaying)
            {
                audio.PlayOneShot(thrust);
            }
            
        }
        else
        {
            audio.Stop();
        }

        
        

    }

    void LeftThrust()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddRelativeForce(Vector3.left * sideThrust * Time.deltaTime);

            
        }
        
    }

    void RightThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.right * sideThrust * Time.deltaTime);
        }
        
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(turningSpeed);

            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-turningSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freeze the rotation so we could manualy rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the phisics system can take over
    }
}
