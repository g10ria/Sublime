using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentLock : MonoBehaviour
{
    public Material newMaterial;
    public GameObject door;

    void OnTriggerEnter(Collider other) {
        door.GetComponent<Collider>().isTrigger = false;
        door.GetComponent<MeshRenderer>().material = newMaterial;
    }

}
