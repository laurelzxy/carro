using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLife = 10;
    private int currentLife;

    public Slider healthSlider; // referência ao slider

    public GameObject gameOverUI;


    void Start()
    {
        currentLife = maxLife;

        if(healthSlider != null)
        {
            healthSlider.maxValue = maxLife;
            healthSlider.value = currentLife;
        }

        if (gameOverUI != null)
            gameOverUI.SetActive(false);  // garante que comece desativado
    }

    public void TakeDamage(int amount)
    {
        currentLife -= amount;
        Debug.Log("Vida atual: " + currentLife);

        UpdateUI();

        if (currentLife <= 0)
        {
            Die();
        }
    }

    public void UpdateUI()
    {
        if(healthSlider != null)
        {
            healthSlider.value = currentLife;
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER!");
        // Reiniciar cena, desativar player, ou mostrar tela de game over

        Time.timeScale = 0; // congela o jogo

        if (gameOverUI != null)
            gameOverUI.SetActive(true);
    }
}
