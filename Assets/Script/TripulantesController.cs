using UnityEngine;

public class TripulantesController : MonoBehaviour
{
    [SerializeField] private int id;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método chamado quando ocorre uma colisão
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Envia uma mensagem para o console com o nome do objeto que colidiu
            Debug.Log("Colidiu com o jogador: " + collision.gameObject.name);
            collision.gameObject.GetComponent<playerControlle>().Evoluir(id);

            // Destroi o objeto que tem este script
            Destroy(gameObject);
        }
    }
}
