using TMPro;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
