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

    [SerializeField] ParticleSystem thrustParticle;
    [SerializeField] ParticleSystem leftSidethrustParticle;
    [SerializeField] ParticleSystem rightSidethrustParticle;



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
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }


    }

 
    void LeftThrust()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            StartLeftThrusting();
        }
        else
        {
            rightSidethrustParticle.Stop();
        }
        
    }

    void RightThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            StartRightThrusting();
            

        }
        else
        {
            leftSidethrustParticle.Stop();
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

    private void StopThrusting()
    {
        audio.Stop();
        thrustParticle.Stop();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
        }

        if (!audio.isPlaying)
        {
            audio.PlayOneShot(thrust);
        }
    }

    private void StartRightThrusting()
    {
        rb.AddRelativeForce(Vector3.right * sideThrust * Time.deltaTime);

        if (!leftSidethrustParticle.isPlaying)
        {
            leftSidethrustParticle.Play();
        }
        else
        {
            return;
        }
    }


    private void StartLeftThrusting()
    {
        rb.AddRelativeForce(Vector3.left * sideThrust * Time.deltaTime);

        if (!rightSidethrustParticle.isPlaying)
        {
            rightSidethrustParticle.Play();
        }
        else
        {
            return;
        }
    }


    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freeze the rotation so we could manualy rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the phisics system can take over
    }
}
