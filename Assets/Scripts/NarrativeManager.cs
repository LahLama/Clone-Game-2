using TMPro;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
