using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

// fix timing
public class HelpHandler : MonoBehaviour
{
    public Canvas HelpCanvas;
    private TMPro.TextMeshProUGUI HelpText;
    private System.Collections.Generic.Stack<HelpText> dialogues;
    private bool inUpdate;

    void Start()
    {
        HelpText = HelpCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        dialogues = new System.Collections.Generic.Stack<HelpText>();
    }

    public void queueText(HelpText text) {
        dialogues.Push(text);
        if (!inUpdate) {
            updateText();
        }
    }

    public void updateText() {
        if (dialogues.Count==0) return;
        inUpdate = true;

        HelpText nextText = dialogues.Pop();
        HelpText.SetText(nextText.dialogue);

        if (dialogues.Count>0) {
            StartCoroutine("updateNext", nextText.displayLength);
        } else {
            inUpdate = false;
            StartCoroutine("wipeText", nextText.displayLength);
        }
        
    }

    IEnumerator updateNext(float seconds) {
        yield return new WaitForSeconds(seconds);
        updateText();
        yield return null;
    }

    IEnumerator wipeText(float seconds) {
        yield return new WaitForSeconds(seconds);
        HelpText.SetText("");
        yield return null;
    }
}
