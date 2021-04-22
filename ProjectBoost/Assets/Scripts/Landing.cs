using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{
    AudioSource audio;
    int currentScene;

    
    private void OnCollisionEnter(Collision other)
    {
        audio = GetComponent<AudioSource>();
        if(other.gameObject.tag == "Player")
        {
            audio.Play();

        }

        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);

    }
}
