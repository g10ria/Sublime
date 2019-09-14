using System.Collections;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public Canvas InventoryCanvas;
    private ArrayList items;
    private TMPro.TextMeshProUGUI InventoryText;
    void Start()
    {
        items = new ArrayList();
        InventoryText = InventoryCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        updateText();
    }

    public void updateText() {
        string text = "";
        foreach(string item in items)
            text += item + "\n";
        InventoryText.SetText(text);
    }

    public void addItem(string item) {
        items.Add(item);
        updateText();
    }

    public void removeItem(string item) {
        if (items.Contains(item)) {
            items.Remove(item);
        }
    }

    public ArrayList getItems() {
        return items;
    }
}
