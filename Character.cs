using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed = 1f;
    public float JumpSpeed = 1f;
    public float fallMultipler = 2.5f;
    public float lowJumpMultipler = 2f;
    public float DuckSpeed;
    public float maxFallSpeed = -5f;
    public float waterMultiplier = 0.3f;

    public float minWaterVerticalSpeed = 3f;
    public float maxWaterVerticalSpeed = -2f;

    private float moveInput;

    private CollisionHandler colHandler;
    private bool inInteraction = false;

    private NPCHandler currNPC;

    public bool underWater;
    
    Rigidbody rb;
    
    void Awake() {
        rb = GetComponent<Rigidbody>();
        colHandler = GetComponent<CollisionHandler>();
    }

    private void LateUpdate() {

        if (!colHandler.underwater()) {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics2D.gravity.y * (fallMultipler - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            { // increases fall speed when going up
                rb.velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;
            }
        }
        
    }

    void FixedUpdate() {
        moveInput = Input.GetAxis("Horizontal");
        var multiplier = 1f;
        if (colHandler.underwater()) multiplier = waterMultiplier;
        rb.velocity = new Vector3(moveInput * Speed * multiplier, rb.velocity.y, 0f);
    }

    // Update is called once per frame
    void Update() {
        var multipler = 1f;
        if (colHandler.underwater()) multipler = waterMultiplier;
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rb.velocity = Vector3.up * JumpSpeed * multipler;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            if (rb.velocity.y-DuckSpeed>maxFallSpeed) rb.velocity -= Vector3.up * DuckSpeed * multipler;
        }

        if (colHandler.underwater()) {
            rb.velocity = Vector3.up * Mathf.Min(rb.velocity.y, maxWaterVerticalSpeed);
            rb.velocity = Vector3.up * Mathf.Max(rb.velocity.y, minWaterVerticalSpeed);
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            if (inInteraction || colHandler.canAccessNPC()) {
                if (!inInteraction) currNPC = colHandler.currNPC();
                inInteraction = currNPC.interact();
            }
        }
    }
}
