using UnityEngine;

public class playerControlle : MonoBehaviour
{
    [SerializeField] private GameObject Cabeca; // Prefab do tiro
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int energia_total = 100;
    [SerializeField] private int energia_atual;
    public bool Cura = false;
    public bool Navegar = false;
    public bool Atirar = false;
    public bool Engenheiro = false;

    [SerializeField] private GameObject tiroPrefab; // Prefab do tiro
    [SerializeField] private float velocidadeTiro = 10f; // Velocidade do tiro
    [SerializeField] private float rotacaoSpeed = 100.0f; // Velocidade de rotação


    void Start()
    {
        speed = 5.0f;
        energia_total = 100;
        energia_atual = energia_total;
    }

    void Update()
    {
        if (Cura)
        {
            CuraStart();
        }
        if (Atirar)
        {
            AtirarStart();
        }

        float dz = Input.GetAxis("Vertical") * Time.deltaTime * speed * -1;
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if (transform.position.x + dx < 900)
        {
            if (transform.position.x - dx > -900)
            {
                if (transform.position.z + dz < 900)
                {
                    if (transform.position.z - dz > -900)
                    {
                        transform.Translate(dx, 0, dz);
                    }
                }
            }
        }

        // Rotaciona para a esquerda (Q)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotacaoSpeed * Time.deltaTime, 0);
        }

        // Rotaciona para a direita (E)
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotacaoSpeed * Time.deltaTime, 0);
        }

        // Mover para posição específica (0, 500, 0) ao pressionar N
        if (Input.GetKeyDown(KeyCode.N))
        {
            MoverParaPosicaoEspecifica(new Vector3(0, 503, 0));
        }

        // Mover para posição aleatória entre -430 e 430 ao pressionar P
        if (Input.GetKeyDown(KeyCode.P))
        {
            MoverParaPosicaoAleatoria(-430, 430);
        }
    }
    // Método para mover o jogador para uma posição específica
    private void MoverParaPosicaoEspecifica(Vector3 posicao)
    {
        transform.position = posicao;
        Debug.Log("Movido para posição específica: " + posicao);
    }

    // Método para mover o jogador para uma posição aleatória dentro de um intervalo
    private void MoverParaPosicaoAleatoria(float min, float max)
    {
        float x = Random.Range(min, max);
        float y = 100; // transform.position.y; Mantém a mesma altura
        float z = Random.Range(min, max);

        Vector3 posicaoAleatoria = new Vector3(x, y, z);
        transform.position = posicaoAleatoria;

        Debug.Log("Movido para posição aleatória: " + posicaoAleatoria);
    }

    public void Evoluir(int id)
    {
        switch (id)
        {
            case 1:
                Cura = true;
                Debug.Log("Cura");
                break;
            case 2:
                Navegar = true;
                Debug.Log("Navegar");
                break;
            case 3:
                Atirar = true;
                Debug.Log("Atirar");
                break;
            case 4:
                Engenheiro = true;
                Debug.Log("Engenheiro");
                break;
            default:
                break;
        }
    }

    public bool Permicao(int id)
    {
        switch (id)
        {
            case 1:
                return Cura;
            case 2:
                return Navegar;
            case 3:
                return Atirar;
            case 4:
                return Engenheiro;
            default:
                return false;
        }
    }
    public void CuraStart()
    {
        if (energia_atual < energia_total)
        {
            energia_atual += 10;
        }
    }

    public void DanoStart()
    {
        energia_atual -= 10;
    }

    public void AtirarStart()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Atira ao pressionar a tecla Espaço
        {
            // Instancia o tiro na posição e rotação do jogador
            GameObject tiro = Instantiate(tiroPrefab, Cabeca.transform.position, Cabeca.transform.rotation);

            tiro.GetComponent<Rigidbody>().linearVelocity = transform.forward * velocidadeTiro * - 1; // Adiciona velocidade ao tiro

        }
    }

    public void NavegarStart()
    {
        // Navegar
    }
    public int getEnergiaTotal()
    {
        return energia_total;
    }

    public int getEnergiaAtual()
    {
        return energia_atual;
    }
}