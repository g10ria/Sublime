using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipHandler : MonoBehaviour
{
    public TMPro.TextMeshPro tooltip;
    private MeshRenderer tooltipRenderer;

    void Start() {
        tooltipRenderer = tooltip.gameObject.GetComponent<MeshRenderer>();
    }

    public string current() {
        return tooltip.text;
    }

    public void showText(string tip) {
        show();
        tooltip.text = tip;
    }

    public void show() {
        tooltipRenderer.enabled = true;
    }

    public void hide() {
        tooltipRenderer.enabled = false;
    }

    public bool status() {
        return tooltipRenderer.enabled;
    }

    public bool toggle() {
        tooltipRenderer.enabled = !tooltipRenderer.enabled;
        return !tooltipRenderer.enabled;
    }
}
