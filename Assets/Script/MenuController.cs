using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelGameOver;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevel);
    }
    public void Sair()
    {
        Debug.Log("Saindo do jogo");
        Application.Quit();
    }
    public void GameOver()
    {
        painelMenuInicial.SetActive(false);
        painelGameOver.SetActive(true);
    }
}
