using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An overarching superclass that extends to all NPCs in a given scene.
// Abstraction for extensible implementation of individual NPCs.
// Also, ease of access for CollisonHandler.
public abstract class NPCHandler : MonoBehaviour
{
    // public references to objects that may be affected by an interaction
    // this list may be expanded as fit
    public GameObject player;
    public Canvas DialogBox;

    protected int totalInteractions;
    protected int completedInteractions;

    protected List<Interaction> interactions;

    protected int allottedInteractions;
    protected int usedInteractions;

    // Initiates some variables as well as the list of interactions.
    void Start() {
        setAllottedAndUsedInteractions();
        interactions = new List<Interaction>();
        initiateInteractions();
        interactions.Add(new EndInteraction());
        totalInteractions = interactions.Count;
        completedInteractions = 0;
    }

    // Completes the next interaction with a NPC, using helper method nextInteraction
    // @return if there are more interaction(s) after this one
    public bool interact() {
        bool moreInt = nextInteraction();

        completedInteractions++;
        return moreInt;
    }

    
    // Completes the interaction with given index, to be implemented by the subclass
    // This layer of abstraction accounts for NPCs that may reuse, skip, or use
    // different dialog paths according to RNG or the character's selections.
    // This method also returns if there is further interaction after this one.
    // This implementation is also left to the subclasses because, as mentioned
    // earlier, NPC dialog graphs can be very circular and even never-ending.
    public abstract bool nextInteraction();

    // Initiates the interactions for a given NPC, to be implemented by the subclass
    // This layer of abstraction allows NPCs to have a rich range of different types of Interactions, in different orders.
    public abstract void initiateInteractions();

    // sets the amount of interactions a character can have and the amount of interactions
    // a character has used. mostly just here as a reminder.
    // set allotted to -1 for unlimited interactions.
    public abstract void setAllottedAndUsedInteractions();
}
