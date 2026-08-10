using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Placing : MonoBehaviour, IPointerDownHandler
{
    InputSystem_Actions inputActions;
[SerializeField] GameObject[] breakableBlocks;
    void Awake()
    {
        inputActions = new InputSystem_Actions();
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
            Debug.Log(block.name);}
        }

        Debug.Log(breakableBlocks);
            // if (eventData.button == PointerEventData.InputButton.Left)
            // // {
            // // Debug.Log("LEFT CLICKKKKKKKKKK");
            // //     // left click logic
            // // }
            Debug.Log("*");

       
    //    if (!newBlock.activeSelf)
    //     {
    //         Debug.Log(newBlock);
    //         Vector2 screenPos = inputActions.UI.Point.ReadValue<Vector2>();
    //         Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f));
    //         newBlock.SetActive(true);
    //         newBlock.transform.position = worldPos;
    //         Debug.Log(worldPos);

    //         Color itemColor = newBlock.GetComponent<SpriteRenderer>().color;
    //         itemColor.a = 1;
    //         newBlock.GetComponent<SpriteRenderer>().color = itemColor;
    //     }
    //     else
    //      newBlock = GameObject.FindWithTag("Breakable");
    }
    
}
