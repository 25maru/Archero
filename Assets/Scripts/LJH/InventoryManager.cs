using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public static InventoryManager Instance { get { return instance; } }

    InventoryHandler inventoryHandler;
    public InventoryHandler InventoryHandler { get { return inventoryHandler; } }

    [SerializeField] SetActive setActive;
    public SetActive SetActive { get { return setActive; } }

    [SerializeField] InventoryUI inventoryUI;
    public InventoryUI InventoryUI { get {  return inventoryUI; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        inventoryHandler = GetComponent<InventoryHandler>();
    }
}
