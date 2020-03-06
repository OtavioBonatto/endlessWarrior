﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float moveSpeed;
    private float moveSpeedInitial;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneInitial;

    private float speedMilestoneCount;
    private float speedMilestoneInitial;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;

    private Rigidbody2D theRB;
    public bool onGround;
    public bool death;
    public LayerMask ground;
    private Collider2D myCollider;
    private Animator theAnim;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        theRB = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        theAnim = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedInitial = moveSpeed;
        speedMilestoneInitial = speedMilestoneCount;
        speedIncreaseMilestoneInitial = speedIncreaseMilestone;

        stoppedJumping = true;
    }

    // Update is called once per frame
    void Update() {

        onGround = Physics2D.IsTouchingLayers(myCollider, ground);
        
        if(transform.position.x > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if(onGround) {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }

        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping) {
            if(jumpTimeCounter > 0) {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            } 
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if(onGround) {
            jumpTimeCounter = jumpTime;
        }

        theAnim.SetFloat("Speed", theRB.velocity.x);
        theAnim.SetBool("onGround", onGround);
        theAnim.SetBool("Death", death);
    }

    public void TouchJump() {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            if(onGround) {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                stoppedJumping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "killbox") {
            death = true;
            //this.enabled = false;
            GameManager.instance.RestartGame();
            moveSpeed = moveSpeedInitial;
            speedMilestoneCount = speedMilestoneInitial;
            speedIncreaseMilestone = speedIncreaseMilestoneInitial;
        }
    }
}
