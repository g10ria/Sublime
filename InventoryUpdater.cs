using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdater : MonoBehaviour
{
    public string[] items;

    void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;
        if (obj.name=="Character") {
            foreach (string item in items)
                obj.GetComponent<InventoryHandler>().addItem(item);
            Object.Destroy(this.gameObject);
        }
    }
}
