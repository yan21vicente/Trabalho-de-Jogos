using UnityEngine;
using UnityEngine.UI;
public class CanvasControlle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Text Energia;
    
    public Text Cura_Cordenada;
    public Text Navegar_Cordenada;
    public Text Atirar_Cordenada;
    public Text Engenheiro_Cordenada;

    public Text Player_Cordenada;

    public Text Cura;
    public Text Navegar;
    public Text Atirar;
    public Text Engenheiro;
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
        
        if(player.GetComponent<playerControlle>().Navegar){
            Cura_Cordenada.text = "("+GameObject.FindWithTag("Medico")?.transform.position.x.ToString() + " " + GameObject.FindWithTag("Medico")?.transform.position.z.ToString()+")";
            if(Cura_Cordenada.text == "( )"){
                Cura_Cordenada.text = "";
            }

            Atirar_Cordenada.text = "("+GameObject.FindWithTag("Armeiro")?.transform.position.x.ToString() + " " + GameObject.FindWithTag("Armeiro")?.transform.position.z.ToString()+")";
            if(Atirar_Cordenada.text == "( )"){
                Atirar_Cordenada.text = "";
            }
            Engenheiro_Cordenada.text = "("+GameObject.FindWithTag("Engenheiro")?.transform.position.x.ToString() + " " + GameObject.FindWithTag("Engenheiro")?.transform.position.z.ToString()+")";
            if(Engenheiro_Cordenada.text == "( )"){
                Engenheiro_Cordenada.text = "";
            }
        }

        Navegar_Cordenada.text = "("+GameObject.FindWithTag("Navegador")?.transform.position.x.ToString() + " " + GameObject.FindWithTag("Navegador")?.transform.position.z.ToString()+")";
        if(Navegar_Cordenada.text == "( )"){
            Navegar_Cordenada.text = "";
        }

        Player_Cordenada.text = "("+player.transform.position.x.ToString() + " " + player.transform.position.z.ToString()+")";
        Energia.text = player.GetComponent<playerControlle>().getEnergiaAtual().ToString()+"/"+player.GetComponent<playerControlle>().getEnergiaTotal().ToString();
    }
}
