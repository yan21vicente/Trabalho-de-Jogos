using UnityEngine;
using UnityEngine.UI;
public class CanvasControlle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Slider barraEnergia;
    public Text Cura;
    public Text Navegar;
    public Text Atirar;
    public Text Engenheiro;
    public Text Escudeiro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cura.text = player.GetComponent<playerControlle>().Cura.ToString();
        Navegar.text = player.GetComponent<playerControlle>().Navegar.ToString();
        Atirar.text = player.GetComponent<playerControlle>().Atirar.ToString();
        Engenheiro.text = player.GetComponent<playerControlle>().Engenheiro.ToString();

        barraEnergia.maxValue = player.GetComponent<playerControlle>().getEnergiaTotal();
        barraEnergia.minValue = 0;
        barraEnergia.value = player.GetComponent<playerControlle>().getEnergiaAtual();

    }
}
