using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour {

    public float rotateSpeed = 1f;
    public bool clockwise = true;


    void FixedUpdate() {
        if (clockwise) transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        else transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
    }
}