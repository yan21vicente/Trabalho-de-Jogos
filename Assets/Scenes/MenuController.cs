using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelHistoria;
    [SerializeField] private GameObject painelComandos;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevel);
    }
    public void Historia()
    {
        painelMenuInicial.SetActive(false);
        painelHistoria.SetActive(true);
    }
    public void Comandos()
    {
        painelMenuInicial.SetActive(false);
        painelComandos.SetActive(true);
    }
    public void Voltar()
    {
        painelHistoria.SetActive(false);
        painelComandos.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void Sair()
    {
        Debug.Log("Saindo do jogo");
        Application.Quit();
    }
}
