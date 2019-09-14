using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A pretty broad class. Basically handles everything in relation to points.
public class PointHandler : MonoBehaviour
{
    public Canvas PointCanvas;
    private TMPro.TextMeshProUGUI PointText;

    private float points;

    private Dictionary<string, System.Action> handlers;
    private GameObject currObj = null; // for ease of access between methods
    
    void Start() {
        PointText = PointCanvas.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        points = 0;
        PointText.text = points.ToString();

        initiateHandlers();
    }

    // maps names to handlers
    void initiateHandlers() {
        handlers = new Dictionary<string, System.Action>(){
        { "YellowCoin", () => changeByAndDestroy(1) },
        { "RedCoin", () => changeByAndDestroy(5) },
        { "laserbeam", () => checkLaserOnAndChangeBy(-3) },
        { "laserhammer", () => changeBy(-4) }
    };
    }

    // handles an altercation with a given game object. this makes point transactions clean
    // and easy, as any other class that wishes to make changes to points can call this object
    // with their game object of choice. then, the responsible method in PointHandler will
    // handle the changes. if no method is found, no changes will be made.
    // methods are searched for and mapped according to the object's name property.
    public void handle(GameObject obj) {
        currObj = obj;
        string name = obj.name;
        if (handlers.ContainsKey(name)) handlers[name]();
    }

    // helper for updating the point counter text
    void updateText() {
        PointText.text = points.ToString();
    }

    // changes by a given amount and destroys the given game object
    void changeByAndDestroy(int amount) {
        Object.Destroy(currObj);
        changeBy(amount);
    }
    
    // utility method for laser points
    // checks if the laser is on, if so, subtracts 3 points
    void checkLaserOnAndChangeBy(int amount) {
        if (currObj.transform.GetComponentInParent<LaserHandler>().laserOn) {
            changeBy(amount);
        }
    }

    // changes the point counter by a given amount (positive or negative)
    void changeBy(int amount) {
        points += amount;
        updateText();
    }
}
