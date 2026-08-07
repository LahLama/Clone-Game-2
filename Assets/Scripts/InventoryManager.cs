using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
   public TextMeshProUGUI _itemCounter;
   int numberOfItems = 0;

   public void SetItemCounter(int val)
    {
        numberOfItems = val;
        _itemCounter.text =numberOfItems.ToString();
    }

    public int GetItemCounter()
    {
        return numberOfItems;
    }

    public void AddItemCounter(int val)
    {
        numberOfItems += val;
        _itemCounter.text = numberOfItems.ToString();
    }
}
