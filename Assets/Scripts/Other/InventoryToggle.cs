using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryPanel;
    public bool isActive;

    void Update()
    {
        isActive = inventoryPanel.activeSelf;


        if (Input.GetKeyDown(KeyCode.E)) inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
