
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colission : MonoBehaviour
{
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip obstacleHit;

    AudioSource audioS;

    private void OnCollisionEnter(Collision other)
    {
        

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
        GetComponent<Movement>().enabled = false;
        audioS = GetComponent<AudioSource>();
        audioS.PlayOneShot(crash);

        Rigidbody rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;


        Invoke("ReloadeScene",1f);
    }

    private void ReloadeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
