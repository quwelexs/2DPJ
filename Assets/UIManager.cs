using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public Image[] hearts;
    public GameObject winPanel;

    void OnEnable()
    {
        GameEvents.OnCoinCollected += UpdateCoinsDisplay;
        GameEvents.OnPlayerDamaged += UpdateHeartsDisplay;
        GameEvents.OnLevelFinished += ShowWinScreen;
    }

    void OnDisable()
    {
        GameEvents.OnCoinCollected -= UpdateCoinsDisplay;
        GameEvents.OnPlayerDamaged -= UpdateHeartsDisplay;
        GameEvents.OnLevelFinished -= ShowWinScreen;
    }

    void UpdateCoinsDisplay(int amount)
    {
        coinsText.text = "Монети: " + amount;
    }

    void UpdateHeartsDisplay(int currentLives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentLives;
        }
    }

    void ShowWinScreen()
    {
        winPanel.SetActive(true); 
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}