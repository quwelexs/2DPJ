using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    private int collectedItems = 0;

    //для об'єктів з istrigger
    void OnTriggerEnter2D(Collider2D other)
    {
        //збір предметів
        if (other.CompareTag("Collectible"))
        {
            collectedItems++;
            Debug.Log("Зібрано предметів: " + collectedItems);
            Destroy(other.gameObject);
        }

        //фініш і перехід на наст. рівень
        if (other.CompareTag("Finish"))
        {
            LoadNextLevel();
        }

        //смерть
        if (other.CompareTag("Hazard1"))
        {
            RestartLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}