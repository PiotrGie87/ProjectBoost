
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colission : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision other)
    {
        string whichTag = other.gameObject.tag;

        switch (whichTag)
        {
            case "Obstacle":
                Debug.Log("Wjeba�es si� na przeszkod�");
                break;

            case "Fuel":
                Debug.Log("Nazryj si�!");
                break;

            case "Friendly":
                Debug.Log("Mi�o tu i sympatycznie, ale zabieraj dup� st�d jak najpr�dzej");
                break;
            case "Finish":
                Debug.Log("Kurwa....uda�o si�");
                break;
            default:
                Debug.Log("Zjeba�e�....sorry");
                ReloadeScene();
                break;



        }
        
    }

    private static void ReloadeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
