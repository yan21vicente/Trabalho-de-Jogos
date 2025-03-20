using UnityEngine;

public class TiroController : MonoBehaviour
{
    private float contadorTempo = 0f;
    private Transform player; // Referência ao transform do jogador
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementa o contador de tempo com o tempo passado desde o último frame
        contadorTempo += Time.deltaTime;

        // Verifica se o contador atingiu o intervalo desejado
        if (contadorTempo >= 30)
        {
            Destroy(gameObject);
            // Reinicia o contador de tempo
            contadorTempo = 0f;
        }
    }
}
