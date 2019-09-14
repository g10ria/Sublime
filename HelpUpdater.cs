using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpUpdater : MonoBehaviour
{
    public HelpText[] dialogues;

    void OnTriggerEnter(Collider other) {
        GameObject obj = other.gameObject;
        if (obj.name=="Character") {
            foreach (HelpText text in dialogues)
                obj.GetComponent<HelpHandler>().queueText(text);
            Object.Destroy(this.gameObject);
        }
    }
}

[System.Serializable]
public class HelpText {
    public HelpText(string dialogue, float displayLength) {
        this.dialogue = dialogue;
        this.displayLength = displayLength;
    }
    public string dialogue;
    public float displayLength; // in seconds
}
