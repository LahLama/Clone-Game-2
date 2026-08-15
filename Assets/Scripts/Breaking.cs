using UnityEngine;
using UnityEngine.EventSystems;
public class Breaking : MonoBehaviour, IPointerClickHandler
{
    int _health = 3;
    InventoryManager inventoryManager;
    void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    public void SetHealthOfBlock(int val)
    {
        _health = val;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _health--;
        Color itemColor = this.GetComponent<SpriteRenderer>().color;
        itemColor.a = ((_health) / 3f);
        this.GetComponent<SpriteRenderer>().color = itemColor;
        if (_health <= 0)
        {
            this.gameObject.SetActive(false);
            inventoryManager.AddItemCounter(+1);
            SoundManager.Instance.PlayBreakBrick();
        }
    }
}