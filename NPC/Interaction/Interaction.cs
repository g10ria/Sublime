using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Interaction class serves as a base class for all NPC/Player interactions
// in this game. Having this overarching superclass allows sub-Interactions to range
// from very simple to very complex, according to the fields they choose to take.
// It also allows the NPCHandler class to maintain a cohesive collection of Interactions.
public abstract class Interaction
{
    // NOTE: add interactor image later
    protected string interactor;

    // Default constructor to be called by subclasses.
    // @param interactor the name of the interactor
    public Interaction(string interactor) {
        this.interactor = interactor;
    }

    // Makes this interaction happen. To be implemented by subclasses.
    public abstract void happen();

    // does any necessary cleanup that occurs after an interaction has finished
    // for example, removing the canvas for text interactions
    public abstract void cleanUp();
}
