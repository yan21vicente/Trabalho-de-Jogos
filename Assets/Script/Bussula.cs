using UnityEngine;

public class Bussula : MonoBehaviour
{
    [SerializeField] private GameObject player; // Referência ao jogador (3D)
    [SerializeField] private GameObject[] tripulantes; // Lista de tripulantes (3D)

    // Update is called once per frame
    void Update()
    {
        // Verifica se há tripulantes e se o jogador está atribuído
        if (tripulantes == null || tripulantes.Length == 0 || player == null)
        {
            Debug.LogWarning("Jogador ou tripulantes não atribuídos.");
            return;
        }

        // Encontra o tripulante mais próximo
        GameObject tripulanteMaisProximo = EncontrarTripulanteMaisProximo();

        // Se houver um tripulante próximo, gira a bússula na direção dele
        if (tripulanteMaisProximo != null)
        {
            GirarParaTripulante(tripulanteMaisProximo);
        }
    }

    // Método para encontrar o tripulante mais próximo do jogador
    private GameObject EncontrarTripulanteMaisProximo()
    {
        GameObject tripulanteMaisProximo = null;
        float menorDistancia = Mathf.Infinity;

        foreach (GameObject tripulante in tripulantes)
        {
            if (tripulante == null) continue;

            // Calcula a distância entre o jogador e o tripulante
            float distancia = Vector3.Distance(player.transform.position, tripulante.transform.position);

            // Atualiza o tripulante mais próximo
            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                tripulanteMaisProximo = tripulante;
            }
        }

        return tripulanteMaisProximo;
    }

    // Método para girar a bússula (2D) na direção do tripulante mais próximo (3D)
    private void GirarParaTripulante(GameObject tripulante)
    {
        // Calcula a direção do jogador para o tripulante no plano XZ (ignora o eixo Y do 3D)
        Vector3 direcao = tripulante.transform.position - player.transform.position;
        direcao.y = 0; // Ignora a altura (eixo Y do 3D)

        // Normaliza a direção para garantir que tenha magnitude 1
        direcao.Normalize();

        // Calcula o ângulo em radianos usando Mathf.Atan2 (considerando X e Z)
        float angulo = Mathf.Atan2(direcao.z, direcao.x) * Mathf.Rad2Deg;

        // Ajusta o ângulo para o sistema 2D (Unity 2D usa o eixo Z para rotação)
        // Como o objeto 2D usa o eixo Y para rotação, convertemos o ângulo corretamente
        transform.rotation = Quaternion.Euler(0, 0, -angulo + 90); // +90 para corrigir a orientação
    }
}