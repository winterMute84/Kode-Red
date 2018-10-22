﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantMovement : MonoBehaviour {

    public Transform player;
    static Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        MutantShoot _MS = GetComponent<MutantShoot>();
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if(Vector3.Distance(player.position, this.transform.position)< 10 && angle < 30){
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if(direction.magnitude > 5){
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", false);
                anim.SetBool("isIdle", false);
                if(direction.magnitude > 7){
                    this.transform.Translate(0, 0, 0.07f);
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isJumping", false);
                    anim.SetBool("isIdle", false);
                    if(direction.magnitude > 8){
                        this.transform.Translate(0,0,0.0f);
                        anim.SetBool("isRunning", false);
                        anim.SetBool("isWalking", false);
                        anim.SetBool("isAttacking", false);
                        anim.SetBool("isJumping", true);
                        anim.SetBool("isIdle", false);
                    }
                }
            }
            else{
                anim.SetBool("isAttacking", true);
                this.transform.Translate(0,0,0.0f);
                _MS.enabled = true;
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", false);
                anim.SetBool("isIdle", false);
            }
        }else{
            anim.SetBool("isIdle", true);
            this.transform.Translate(0,0,0.00f);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
        }
	}
}