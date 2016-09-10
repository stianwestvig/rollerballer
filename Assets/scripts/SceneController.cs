using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    private int sceneCount;
    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // sceneCount = SceneManager.sceneCount;
        // sceneCount API is buggy. Update manually:
        sceneCount = 3;
    }

    
    public void loadNextScene() {
        Start();

        if (currentSceneIndex < sceneCount) {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Application.Quit();
        }
    }
}