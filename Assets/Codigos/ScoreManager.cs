using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI textoPontos;

    private int pontos = 0;

    void Start()
    {
        pontos = 0;
        AtualizarPontos();
    }

    public void AdicionarPonto()
    {
        pontos++;
        AtualizarPontos();

        Debug.Log("Pontos: " + pontos);
    }

    void AtualizarPontos()
    {
        if (textoPontos != null)
        {
            textoPontos.text = pontos.ToString();
        }
    }
}