using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{   
    Collider m_Collider;

    private PointHandler pointHandler;
    private TooltipHandler tooltipHandler;

    private bool withinNPC = false;
    private NPCHandler npc = null;

    private bool withinWater = false;

    private bool justArrived = false;

    void Awake() {
        m_Collider = GetComponent<Collider>();
        pointHandler = GetComponent<PointHandler>();
        tooltipHandler = GetComponent<TooltipHandler>();
    }

    private void OnTriggerEnter(Collider other) {
        pointHandler.handle(other.gameObject);

        print(other.gameObject.name);
        
        if (other.gameObject.name=="NPC") { // NPC Interaction
            withinNPC = true;
            npc = other.gameObject.GetComponent<NPCHandler>();
            tooltipHandler.showText("f");
        } else if (other.gameObject.name=="Water") {
            Physics.gravity = new Vector3(0, 1F, 0);
            withinWater = true;
        } else if (other.gameObject.name=="Portal") {
            if (!justArrived) {
                other.GetComponent<Portal>().port(this.gameObject);
                justArrived = true;
            } else {
                justArrived = false;
            }
        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name=="NPC") {
            tooltipHandler.hide();
            withinNPC = false;
            npc = null;
        } else if (other.gameObject.name=="Water") {
            Physics.gravity = new Vector3(0, -9.81F, 0);
            withinWater = false;
        }
    }

    public bool underwater() {
        return withinWater;
    }

    public bool canAccessNPC() {
        return this.withinNPC;
    }

    public NPCHandler currNPC() {
        return npc;
    }
}
