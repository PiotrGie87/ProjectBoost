using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{
    AudioSource audio;
    int currentScene;
    int nextScene;

    
    private void OnCollisionEnter(Collision other)
    {
        audio = GetComponent<AudioSource>();
        if(other.gameObject.tag == "Player")
        {
            audio.Play();

        }

        Invoke("LoadNextLevel", 1f);

    }

    void LoadNextLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;

        if(SceneManager.sceneCountInBuildSettings == nextScene)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}
