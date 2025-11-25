using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject painelControles; // o GameObject dentro do Canvas

    public GameObject painelMenu;      // painel principal do menu


    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    void Start()
    {
        if (painelControles != null)
            painelControles.SetActive(false); // começa desligado
    }

    public void AbrirControles()
    {
        painelControles.SetActive(true);
        painelMenu.SetActive(false);

    }

    public void FecharControles()
    {
        painelControles.SetActive(false);
        painelMenu.SetActive(true);
    }

   
}
