using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Terrain terreno;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Arvore;
    [SerializeField] private int QuantArvore;
    [SerializeField] private GameObject[] tripulantes;
    [SerializeField] private GameObject inimigo;
    

    [SerializeField] private float intervalo = 30f;

    // Contador de tempo
    private float contadorTempo = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CriarObjetosAleatorios(Arvore, QuantArvore, "Floresta");
        for (int i = 0; i < tripulantes.Length; i++)
        {
            CriarObjetosAleatorios(tripulantes[i], 1, "Tripulantes");
        }
        CriarObjetosAleatorios(inimigo, 30, "Inimigos");
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementa o contador de tempo com o tempo passado desde o último frame
        contadorTempo += Time.deltaTime;

        // Verifica se o contador atingiu o intervalo desejado
        if (contadorTempo >= intervalo)
        {
            CriarObjetosAleatorios(inimigo, 30, "Inimigos");
            // Reinicia o contador de tempo
            contadorTempo = 0f;
        }
    }
    
    private void CriarObjetosAleatorios(GameObject prefab, int quantidade, string nomePai)
    {
        // Verifica se o prefab e o terreno foram atribuídos
        if (prefab == null || terreno == null)
        {
            Debug.LogError("Prefab ou terreno não atribuídos.");
            return;
        }

        // Obtém ou cria o objeto pai
        GameObject pai = GameObject.Find(nomePai);
        if (pai == null)
        {
            // Se o objeto pai não existir, cria um novo
            pai = new GameObject(nomePai);
            Debug.Log("Objeto pai criado: " + nomePai);
        }

        // Obtém o tamanho do terreno
        Vector3 tamanhoTerreno = terreno.terrainData.size;
        float areaMinX = -(tamanhoTerreno.x / 2); // Mínimo em X
        float areaMaxX = tamanhoTerreno.x / 2; // Máximo em X
        float areaMinZ = -(tamanhoTerreno.z / 2); // Mínimo em Z
        float areaMaxZ = tamanhoTerreno.z / 2; // Máximo em Z

        for (int i = 0; i < quantidade; i++)
        {
            // Gera uma posição aleatória dentro do terreno
            Vector3 posicaoAleatoria = new Vector3(
                Random.Range(areaMinX, areaMaxX), // Posição X
                0, // Posição Y (altura)
                Random.Range(areaMinZ, areaMaxZ)  // Posição Z
            );

            // Ajusta a altura (Y) para a altura do terreno naquela posição
            posicaoAleatoria.y = terreno.SampleHeight(posicaoAleatoria);

            // Instancia o objeto na posição aleatória e define o pai
            GameObject novoObjeto = Instantiate(prefab, posicaoAleatoria, Quaternion.identity);
            novoObjeto.transform.parent = pai.transform; // Define o pai
        }
        
        Debug.Log(quantidade + " objetos criados em posições aleatórias dentro do terreno, filhos de " + nomePai + ".");
    }
}
