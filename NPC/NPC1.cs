using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the NPC implementation for the first NPC, in env2 of Red Biome.
// This was an exposition/introduction and slightly fourth-wall-breaking character. :)
public class NPC1 : NPCHandler
{
    // This NPC had a name.
    public string NPC_name;

    // This NPC's interactions were just text interactions with no looping.
    // Data structural representation: linked list.
    public override bool nextInteraction() {
        if (usedInteractions==allottedInteractions) return false;

        if (completedInteractions>0) interactions[completedInteractions-1].cleanUp();
        interactions[completedInteractions].happen();

        bool notcompleted = completedInteractions+1<totalInteractions; // adding 1 because nextInteraction is run before completed is incremented
        if (!notcompleted) {
            completedInteractions = -1;
            usedInteractions++;
        }
        return notcompleted;
    }

    // initiates the text interactions for this NPC
    public override void initiateInteractions() {
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "Hi!", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "Welcome to SUBLIME! The game.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "(Feel free to move around as you listen, I'll still be here)", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "sublime is your average platformer game.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "you can jump around, collect coins, and avoid bad things...", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "that take away your points.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "but more so, sublime is a microsm of life.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "you win some, you lose some, sometimes inevitably.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "everything is well in the end though.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "that's why sublime has no deaths (almost).", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "no matter what happens, just pick yourself up and keep going.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "so off you go then! have fun! enjoy the journey!", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "and thanks for playing sublime.", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "it really means a lot to me", false));
        interactions.Add(new TextInteraction(NPC_name, DialogBox, "(the creator).", false));
    }
    
    // this NPC has unlimited interactinos
    public override void setAllottedAndUsedInteractions() {
        allottedInteractions = -1;
        usedInteractions = 0;
    }
}
