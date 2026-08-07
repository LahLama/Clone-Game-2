using UnityEngine;
using UnityEngine.EventSystems;

public class Breaking : MonoBehaviour, IPointerClickHandler
{
    int _health = 3;

    public void OnPointerClick(PointerEventData eventData)
    {
        _health--;

        if ( _health <= 0 ){
        Debug.Log("ADD TO INVENTORY");
        this.gameObject.SetActive(false);
    }
            Debug.Log("Health of " + this.name + " " + _health);
    }

}
