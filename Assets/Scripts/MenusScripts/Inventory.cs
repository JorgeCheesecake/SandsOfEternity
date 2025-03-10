using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;
    public GameObject inventory;
    private bool inventoryEnabled = false;

    void Start()
    {
        if (inventory == null)
        {
            inventory = GameObject.Find("Inventario");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            Debug.Log("Tecla Tab presionada"); 
            inventoryEnabled = !inventoryEnabled;
            inventory.SetActive(inventoryEnabled);
        }
    }
}
