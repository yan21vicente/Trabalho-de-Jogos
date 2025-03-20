using UnityEngine;

public class EnimigController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f; // Velocidade de movimento do inimigo
    private Transform player; // Referência ao transform do jogador

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Encontra o jogador pela tag "Player"
        player = GameObject.FindWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("Jogador não encontrado. Certifique-se de que o jogador tem a tag 'Player'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Move o inimigo em direção ao jogador
            SeguirJogador();
        }
    }

    // Método para seguir o jogador
    private void SeguirJogador()
    {
        // Calcula a direção para o jogador
        Vector3 direcao = (player.position - transform.position).normalized;

        // Move o inimigo na direção do jogador
        transform.Translate(direcao * speed * Time.deltaTime, Space.World);

        // Opcional: Rotaciona o inimigo para olhar na direção do jogador
        transform.LookAt(player);
    }

    // Método chamado quando ocorre uma colisão
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto colidido tem a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Envia uma mensagem para o console com o nome do objeto que colidiu
            Debug.Log("Colidiu com o jogador: " + collision.gameObject.name);
            collision.gameObject.GetComponent<playerControlle>().DanoStart();
            // Destroi o objeto que tem este script
            //Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Tiro"))
        {
            // Envia uma mensagem para o console com o nome do objeto que colidiu
            Debug.Log("Colidiu com o tiro: " + collision.gameObject.name);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            if(player.GetComponent<playerControlle>().Engenheiro)
            {
                player.GetComponent<playerControlle>().UPEnergiaTotal();
            }
        }
    }
}