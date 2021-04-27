using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{
    [SerializeField] ParticleSystem landingParticle;

    AudioSource audio;
    int currentScene;
    int nextScene;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        audio = GetComponent<AudioSource>();
        if(other.gameObject.tag == "Player")
        {
            audio.Play();

            if (!landingParticle.isPlaying)
            {
                landingParticle.Play();
            }
            else
            {
                return;
            }

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
