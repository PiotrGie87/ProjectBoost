
using UnityEngine;

public class Colission : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        string whichTag = other.gameObject.tag;

        switch (whichTag)
        {
            case "Obstacle":
                Debug.Log("Wjeba³es siê na przeszkodê");
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
                break;



        }
        
    }
}
