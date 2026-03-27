using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    public int lives = 3;
    private int coins = 0;
    private Vector2 currentCheckpoint;

    void Start()
    {
        currentCheckpoint = transform.position; 
        GameEvents.OnCoinCollected?.Invoke(coins);
        GameEvents.OnPlayerDamaged?.Invoke(lives);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //1.монетки
        if (other.CompareTag("Collectible"))
        {
            coins++;
            GameEvents.OnCoinCollected?.Invoke(coins);
            Destroy(other.gameObject);
        }

        //2.чекпоїнт
        else if (other.CompareTag("Checkpoint"))
        {
            currentCheckpoint = transform.position;
        }

        //3.шипи або прірва
        else if (other.CompareTag("Hazard"))
        {
            TakeDamage();
        }

        //4.фініш
        else if (other.CompareTag("Finish"))
        {
            GameEvents.OnLevelFinished?.Invoke();
            gameObject.SetActive(false);
        }
    }

    void TakeDamage()
    {
        lives--;
        GameEvents.OnPlayerDamaged?.Invoke(lives);

        if (lives > 0)
        {
            transform.position = currentCheckpoint;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}