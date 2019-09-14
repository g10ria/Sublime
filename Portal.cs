using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal other;

    public void port(GameObject obj) {
        obj.transform.position = other.transform.position;
    }
}
