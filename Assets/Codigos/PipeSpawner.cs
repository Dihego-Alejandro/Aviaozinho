using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject canoCima;
    public GameObject canoBaixo;
    public GameObject scoreZonePrefab;

    [Header("Posição")]
    public float distanciaX = 20f;

    [Header("Altura")]
    public float alturaMinima = -2f;
    public float alturaMaxima = 3f;

    [Header("Espaço entre os canos")]
    public float tamanhoDoBuraco = 5f;

    [Header("Geração")]
    public float intervalo = 2.5f;

    [Header("Velocidade")]
    public float velocidadeCanos = 5f;

    [Header("Destruição")]
    public float tempoParaDestruir = 15f;

    private float tempo;

    void Start()
    {
        tempo = intervalo;
    }

    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= intervalo)
        {
            CriarParDeCanos();
            tempo = 0f;
        }
    }

    void CriarParDeCanos()
    {
        float altura = Random.Range(
            alturaMinima,
            alturaMaxima
        );

        Vector3 posicao = transform.position;

        posicao.x = distanciaX;

        // =========================
        // CANO DE CIMA
        // =========================

        Vector3 posicaoCima = posicao;

        posicaoCima.y =
            altura + tamanhoDoBuraco / 2f;

        GameObject cima = Instantiate(
            canoCima,
            posicaoCima,
            Quaternion.identity
        );

        PipeMove movimentoCima =
            cima.GetComponent<PipeMove>();

        if (movimentoCima != null)
        {
            movimentoCima.velocidade = velocidadeCanos;
        }

        // =========================
        // CANO DE BAIXO
        // =========================

        Vector3 posicaoBaixo = posicao;

        posicaoBaixo.y =
            altura - tamanhoDoBuraco / 2f;

        GameObject baixo = Instantiate(
            canoBaixo,
            posicaoBaixo,
            Quaternion.identity
        );

        PipeMove movimentoBaixo =
            baixo.GetComponent<PipeMove>();

        if (movimentoBaixo != null)
        {
            movimentoBaixo.velocidade = velocidadeCanos;
        }

        // =========================
        // SCORE ZONE
        // =========================

        Vector3 posicaoScore = posicao;

        posicaoScore.y = altura;

        GameObject scoreZone = Instantiate(
            scoreZonePrefab,
            posicaoScore,
            Quaternion.identity
        );

        PipeMove movimentoScore =
            scoreZone.GetComponent<PipeMove>();

        if (movimentoScore != null)
        {
            movimentoScore.velocidade = velocidadeCanos;
        }

        // =========================
        // DESTRUIR
        // =========================

        Destroy(cima, tempoParaDestruir);
        Destroy(baixo, tempoParaDestruir);
        Destroy(scoreZone, tempoParaDestruir);
    }
}