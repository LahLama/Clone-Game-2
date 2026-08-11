using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [Header("Lose UI")]
    [SerializeField] private GameObject losePanel;

    [Header("Death Triggers")]
    [SerializeField] private string spikeTag = "Spike";
    [SerializeField] private string deathZoneTag = "DeathZone";

    private bool isDead;

    private void Start()
    {
        if (losePanel != null) losePanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDie(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TryDie(other.gameObject);
    }

    private void TryDie(GameObject other)
    {
        if (isDead) return;

        if (other.CompareTag(spikeTag) || other.CompareTag(deathZoneTag))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        if (losePanel != null) losePanel.SetActive(true);

        // Freeze the player in place
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        var movement = GetComponent<PlayerMovement>();
        if (movement != null) movement.enabled = false;

        Time.timeScale = 0f; // pause the game
    }

  
}