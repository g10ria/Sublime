using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This interaction does nothing and is just padding that serves as the last, closing interaction
// in a procession of interactions.
public class EndInteraction : Interaction {
    public EndInteraction() : base("") {

    }
    public override void happen() {
        
    }
    public override void cleanUp() {}
}