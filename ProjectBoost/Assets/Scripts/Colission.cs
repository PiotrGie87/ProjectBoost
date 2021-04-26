
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colission : MonoBehaviour
{
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip obstacleHit;

    AudioSource audioS;

    bool isTransitioning = false;

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
        {
            return;
        }

        string whichTag = other.gameObject.tag;

        switch (whichTag)
        {
            case "Obstacle":
                Debug.Log("Wjeba³es siê na przeszkodê");
                audioS = GetComponent<AudioSource>();
                audioS.PlayOneShot(obstacleHit);
                break;

            case "Fuel":
                Debug.Log("Nazryj siê!");
                break;

            case "Friendly":
                Debug.Log("Mi³o tu i sympatycznie, ale zabieraj dupê st¹d jak najprêdzej");
                break;
            case "Finish":
                Debug.Log("Kurwa....uda³o siê");
                break;
            default:
                Debug.Log("Zjeba³eœ....sorry");

                StartCrashSequence();
                //ReloadeScene();
                break;



        }
        
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        
        GetComponent<Movement>().enabled = false;
        audioS = GetComponent<AudioSource>();
        audioS.Stop();
        audioS.PlayOneShot(crash);
        

        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.constraints = RigidbodyConstraints.FreezeAll;


        Invoke("ReloadeScene",1f);
    }

    private void ReloadeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
