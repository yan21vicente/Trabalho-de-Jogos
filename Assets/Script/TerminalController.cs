using UnityEngine;

public class TerminalController : MonoBehaviour
{
    [SerializeField] private GameObject prefabParaInstanciar; // Prefab que será instanciado
    [SerializeField] private Material materialAtual; // Material do objeto atual

    [SerializeField] private bool premicao = false;

    [SerializeField] private int id;

    private int objetos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtém o material do objeto atual
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            materialAtual = renderer.material;
        }
        else
        {
            Debug.LogError("O objeto não tem um Renderer anexado.");
        }
    }

    // Método chamado quando um objeto entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entrou no trigger.");
        // Verifica se o objeto que entrou no trigger tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            premicao = other.gameObject.GetComponent<playerControlle>().Permicao(id);
            // Verifica se o jogador tem permissão para criar um novo objeto
            if(premicao && objetos < 1)
            {
                // Calcula a posição do novo objeto (0.3 unidades acima no eixo Y)
                Vector3 posicaoNovoObjeto = transform.position + new Vector3(0, 0.3f, 0);

                // Calcula a rotação do novo objeto (180 graus em Y em relação ao jogador)
                Quaternion rotacaoNovoObjeto = Quaternion.Euler(0, other.transform.rotation.eulerAngles.y + 180, 0);

                // Instancia o novo objeto na posição e rotação calculadas
                GameObject novoObjeto = Instantiate(prefabParaInstanciar, posicaoNovoObjeto, rotacaoNovoObjeto);

                // Aplica o material do objeto atual ao novo objeto
                Renderer novoRenderer = novoObjeto.GetComponent<Renderer>();
                if (novoRenderer != null)
                {
                    novoRenderer.material = materialAtual;
                }
                else
                {
                    Debug.LogError("O prefab instanciado não tem um Renderer anexado.");
                }

                // Ajusta o tamanho do novo objeto com base no tamanho do jogador
                AjustarTamanhoProporcionalAoJogador(novoObjeto, other.transform);

                Debug.Log("Novo objeto criado com o material do objeto atual e tamanho proporcional ao jogador.");
                objetos++;
            }
            else
            {
                Debug.Log("Você não tem permissão para criar um novo objeto.");
            }
        }
    }

    // Método para ajustar o tamanho do novo objeto proporcionalmente ao jogador
    private void AjustarTamanhoProporcionalAoJogador(GameObject novoObjeto, Transform jogador)
    {
        // Obtém a escala do jogador
        Vector3 escalaJogador = jogador.localScale;

        // Calcula a nova escala com base na proporção definida
        Vector3 novaEscala = escalaJogador * 1.5f;

        // Aplica a nova escala ao novo objeto
        novoObjeto.transform.localScale = novaEscala;
    }
}