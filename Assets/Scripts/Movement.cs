using System;
using UnityEngine;
using UnityEngine.Serialization;


public class Movement : MonoBehaviour
{
    public int baseSpeed;
    public float speedMult;

    public float speed;

    public CraftingStation station;

    public GameObject[] benchCraftedItems;
    public GameObject[] furnaceCraftedItems;
    public GameObject[] anvilCraftedItems;

    private void FixedUpdate()
    {
        speed = baseSpeed * (1 + speedMult);
        Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        var transform1 = transform;

        transform1.position =
            transform1.position + horizontal * (Time.deltaTime * speed) + vertical * (Time.deltaTime * speed);
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        {
        
            if (col.gameObject.CompareTag("CraftingStation"))
            {
                if (col.gameObject.GetComponent<CraftingStation>().stationName == type.Bench)
                {
                    foreach (var t in benchCraftedItems)
                    {
                        t.SetActive(true);
                    }
                }

                if (col.gameObject.GetComponent<CraftingStation>().stationName == type.Furnace)
                {
                    foreach (var t in furnaceCraftedItems)
                    {
                        t.SetActive(true);
                    }
                }

                if (col.gameObject.GetComponent<CraftingStation>().stationName == type.Anvil)
                {
                    foreach (var t in anvilCraftedItems)
                    {
                        t.SetActive(true);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("CraftingStation"))
        {
            
            if (col.gameObject.GetComponent<CraftingStation>().stationName == type.Bench)
            {
                foreach (var t in benchCraftedItems)
                {
                    t.SetActive(false);
                }
            }

            if (col.gameObject.GetComponent<CraftingStation>().stationName == type.Furnace)
            {
                foreach (var t in furnaceCraftedItems)
                {
                    t.SetActive(false);
                }
            }

            if (col.gameObject.GetComponent<CraftingStation>().stationName == type.Anvil)
            {
                foreach (var t in anvilCraftedItems)
                {
                    t.SetActive(false);
                }
            }
        }
    }
}
