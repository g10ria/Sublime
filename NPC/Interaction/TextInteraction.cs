using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A text interaction is the most common type of interaction. It consists only
// of a piece of dialog in the dialog box.
public class TextInteraction : Interaction
{

    [SerializeField]
    private string text;
    private Canvas DialogBox;
    private bool nextText;

    private TMPro.TextMeshProUGUI DialogText;

    // Creates a new TextInteraction.
    // @param interactor the name of the interactor
    // @param DialogBox the box for text dialog
    // @param text the text for this text interaction
    // @param nextText if the next interaction involves the DialogBox as well
    public TextInteraction(string interactor, Canvas DialogBox, string text, bool nextText) : base(interactor) {
        this.DialogBox = DialogBox;
        this.text = text;
        this.nextText = nextText;
        DialogText = DialogBox.GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    // NOTE: add nicer formatting in dialog box
    // NOTE: add scrolling in, icon, etc.
    public override void happen() {
        if (!DialogBox.GetComponent<Canvas>().enabled) {
            DialogBox.GetComponent<Canvas>().enabled = true;
        }
        DialogText.text = this.interactor+":\n"+this.text;
    }

    // cleans up by un-showing the text box according to the 
    // nextText property
    public override void cleanUp() {
        if (!nextText) {
            DialogBox.GetComponent<Canvas>().enabled = false;
        }
    }
}
