using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class Placing : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerExitHandler
{
    InputSystem_Actions inputActions;
    [SerializeField] List<GameObject> breakableBlocks;
    public GameObject VisualBlock;
    InventoryManager inventoryManager;
    public float blockSize = 1f;
    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        if (inventoryManager.GetItemCounter() <= 0)
        {
            VisualBlock.SetActive(false);
            return;
        }
        Mouse.current.WarpCursorPosition(new Vector2(
            Mathf.Round(Mouse.current.position.ReadValue().x / blockSize) * blockSize,
            Mathf.Round(Mouse.current.position.ReadValue().y / blockSize) * blockSize
        ));
        Vector2 screenPos = inputActions.UI.Point.ReadValue<Vector2>();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f));
        VisualBlock.SetActive(true);
        VisualBlock.transform.position = new Vector3(
                Mathf.Round(worldPos.x / blockSize) * blockSize,
                Mathf.Round(worldPos.y / blockSize) * blockSize,
                worldPos.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        VisualBlock.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        foreach (GameObject block in breakableBlocks)
        {
            if (!block.gameObject.activeSelf)
            {
                Vector2 screenPos = inputActions.UI.Point.ReadValue<Vector2>();


                Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10f));
                block.SetActive(true);
                block.transform.position = new Vector3(
                    Mathf.Round(worldPos.x / blockSize) * blockSize,
                    Mathf.Round(worldPos.y / blockSize) * blockSize,
                    worldPos.z
                );
                block.GetComponent<Breaking>().enabled = false;
                inventoryManager.AddItemCounter(-1);

                Color itemColor = block.GetComponent<SpriteRenderer>().color;
                itemColor.a = 1;
                block.GetComponent<SpriteRenderer>().color = itemColor;
                SoundManager.Instance.PlayPlaceBrick();
                return;
            }
        }

        Debug.Log("*");


    }
}