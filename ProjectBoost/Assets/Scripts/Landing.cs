using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    AudioSource audio;
    
    private void OnCollisionEnter(Collision other)
    {
        audio = GetComponent<AudioSource>();
        if(other.gameObject.tag == "Player")
        {
            audio.Play();

        }
    }
}
