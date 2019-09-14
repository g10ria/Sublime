using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHandler : MonoBehaviour
{
    public float offset = 0f;
    public float SwitchInterval = 1.25f;
    private float timeSinceSwitch = 0f;
    public bool laserOn = true;
    private GameObject laserBeam;
    private MeshRenderer laserRenderer;
    // Start is called before the first frame update
    void Start()
    {
        laserBeam = this.gameObject.transform.GetChild(1).gameObject;
        laserRenderer = laserBeam.GetComponent<MeshRenderer>();
        timeSinceSwitch -= offset;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSwitch += Time.deltaTime;
        if (timeSinceSwitch>=SwitchInterval) {
            laserOn = !laserOn;
            timeSinceSwitch = 0;
            laserRenderer.enabled = laserOn;
        }
    }
}