using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [Header("Win UI")]
    [SerializeField] private GameObject winPanel;

    [Header("Win Trigger")]
    [SerializeField] private string goalTag = "Goal";

    private bool hasWon;

    private void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger entered by: {other.gameObject.name}, tag: {other.tag}, hasWon: {hasWon}, winPanel assigned: {winPanel != null}");

        if (hasWon) return;

        if (other.CompareTag(goalTag))
        {
            Win();
        }
    }

    private void Win()
    {
        Debug.Log("Win() called");
        hasWon = true;

        if (winPanel != null) winPanel.SetActive(true);

        var rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        var movement = GetComponent<PlayerMovement>();
        if (movement != null) movement.enabled = false;

        Time.timeScale = 0f;
    }
}