using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Placing : MonoBehaviour, IPointerDownHandler
{
    InputSystem_Actions inputActions;
[SerializeField] List<GameObject> breakableBlocks;
 InventoryManager inventoryManager;
    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    //Enables New Input System
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }


    public void OnPointerDown(PointerEventData eventData)
    {   
        

        foreach (GameObject block in breakableBlocks)
        {
            if (!block.gameObject.activeSelf){
            // Debug.Log(block.name);

            Vector2 screenPos = inputActions.UI.Point.ReadValue<Vector2>();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f));
            block.SetActive(true);
            block.transform.position = worldPos;
            
            block.GetComponent<Breaking>().enabled = false;
            inventoryManager.AddItemCounter(-1);
            
            Color itemColor = block.GetComponent<SpriteRenderer>().color;
            itemColor.a = 1;
            block.GetComponent<SpriteRenderer>().color = itemColor;


            return;
            }
        }

       
            // if (eventData.button == PointerEventData.InputButton.Left)
            // // {
            // // Debug.Log("LEFT CLICKKKKKKKKKK");
            // //     // left click logic
            // // }
            Debug.Log("*");

       
      
    }
    
}
