using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{

    public string[] neededKeys;
    private string keyString;

    void Start() {
        keyString = "Need key";
        if (neededKeys.Length>1) keyString +="s";
        foreach (string key in neededKeys) {
            keyString += " " + key;
        }
        keyString += ".";
    }

    public bool checkUnlocked(GameObject other, bool removeUsedKeys) {
        bool enoughKeys = true;

        InventoryHandler inventory = other.GetComponent<InventoryHandler>();
        ArrayList ownedItems = inventory.getItems();

        foreach(string key in neededKeys) {
            if (!ownedItems.Contains(key)) enoughKeys = false;
        }

        if (enoughKeys) {
            foreach(string key in neededKeys) {
                inventory.removeItem(key);
            }
            return true;
        } else {
            other.gameObject.GetComponent<HelpHandler>().queueText(new HelpText(keyString, 5));
            return false;
        }
    }
}
