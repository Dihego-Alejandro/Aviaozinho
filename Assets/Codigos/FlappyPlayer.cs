using UnityEngine;

public class FlappyPlayer : MonoBehaviour
{
    public float forcaDoPulo = 7f;

    [Header("Modelo do avião")]
    public Transform modeloAviao;

    [Header("Inclinação")]
    public float anguloSubindo = 25f;
    public float anguloCaindo = -30f;
    public float velocidadeRotacao = 5f;

    private Rigidbody rb;
    private AudioSource audioSource;
    private Quaternion rotacaoInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        if (modeloAviao != null)
        {
            rotacaoInicial = modeloAviao.localRotation;
        }
    }

    void Update()
    {
        // Computador: Espaço
        bool apertouEspaco = Input.GetKeyDown(KeyCode.Space);

        // Celular: toque na tela
        bool tocouNaTela = Input.touchCount > 0 &&
                           Input.GetTouch(0).phase == TouchPhase.Began;

        if (apertouEspaco || tocouNaTela)
        {
            Pular();
        }

        InclinarAviao();
    }

    void Pular()
    {
        rb.linearVelocity = new Vector3(
            0f,
            forcaDoPulo,
            0f
        );

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void InclinarAviao()
    {
        if (modeloAviao == null)
            return;

        float angulo;

        if (rb.linearVelocity.y > 0)
        {
            angulo = anguloSubindo;
        }
        else
        {
            angulo = anguloCaindo;
        }

        Quaternion rotacaoDesejada =
            rotacaoInicial *
            Quaternion.AngleAxis(
                angulo,
                Vector3.right
            );

        modeloAviao.localRotation = Quaternion.Lerp(
            modeloAviao.localRotation,
            rotacaoDesejada,
            velocidadeRotacao * Time.deltaTime
        );
    }
}