using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpManager : MonoBehaviour
{
    // Reference to the pop-up UI or manager
    public GameObject popUpUI;

    // Delay before loading the new scene (in seconds)
    public float sceneLoadDelay = 0f;

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Opened2");
        if (other.CompareTag("Player"))
        {
            // Show pop-up UI or manager
            Debug.Log("Opened1");
            if (popUpUI != null)
            {
                popUpUI.SetActive(true);
            }

            // Start the process to load the new scene after a delay
            Invoke("LoadNewScene", sceneLoadDelay);
        }
    }

    void LoadNewScene()
    {
        // Load the "SampleScene2" scene
        Debug.Log("Opened");
        SceneManager.LoadScene("SampleScene2");
    }
}
