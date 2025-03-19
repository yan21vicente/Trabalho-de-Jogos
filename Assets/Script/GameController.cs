using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Terrain terreno;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Arvore;
    [SerializeField] private Transform objetoGuia; 
    [SerializeField] private GameObject[] tripulantes;
    [SerializeField] private GameObject inimigo;

    [SerializeField] private double x1;
    [SerializeField] private double y1;
    [SerializeField] private double x2;
    [SerializeField] private double y2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CriarObjetosAleatorios(Arvore, 10, "Floresta");
        for (int i = 0; i < tripulantes.Length; i++)
        {
            CriarObjetosAleatorios(tripulantes[i], 1, "Tripulantes");
        }

        CalcularGrau(x1, y1, x2, y2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public double CalcularGrau(double x1,double  y1,double  x2,double  y2)
    {

        // Calcula a diferença entre as coordenadas
        double deltaX = x2 - x1;
        double deltaY = y2 - y1;

        // Calcula o ângulo em radianos usando Math.Atan2
        double anguloRadianos = Math.Atan2(deltaY, deltaX);

        // Converte o ângulo de radianos para graus
        double anguloGraus = anguloRadianos * (180 / Math.PI);

        // Ajusta o ângulo para garantir que esteja no intervalo [0, 360)
        if (anguloGraus < 0)
        {
            anguloGraus += 360;
        }

        // Exibe o resultado
        Console.WriteLine($"O ângulo entre os pontos é: {anguloGraus} graus.");
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
