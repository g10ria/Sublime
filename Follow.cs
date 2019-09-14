using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Follow : MonoBehaviour
{
    public Transform target;
    public float deltaX;
    public float deltaY;
    public float deltaZ;

    void LateUpdate() {
        this.transform.position = new Vector3(target.position.x + deltaX, target.position.y+deltaY, target.position.z + deltaZ);
    }
}
