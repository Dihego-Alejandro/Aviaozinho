using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool jaMarcou = false;

    private void OnTriggerEnter(Collider other)
    {
        if (jaMarcou)
            return;

        PlayerDeath jogador = other.GetComponentInParent<PlayerDeath>();

        if (jogador != null)
        {
            jaMarcou = true;

            ScoreManager scoreManager =
                FindFirstObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.AdicionarPonto();
            }

            Destroy(gameObject);
        }
    }
}