﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class ReactiveTarget : MonoBehaviour
{
    private Animator _anim;
    private SceneController _sceneController;
    


    void Start()
    {
        _anim = GetComponent<Animator>();
        _sceneController = GameObject.Find("Controller").GetComponent<SceneController>();


    }


    public void ReactToHit()
    {
        StaticShootingEnemy staticShootingEnemy = GetComponent<StaticShootingEnemy>();
        if ( staticShootingEnemy!= null)
            staticShootingEnemy.SetAlive(false);

        MutantShoot ms = GetComponent<MutantShoot>();
        if(ms != null)
            ms.SetAlive(false);
        

        BystanderMovement byStander = GetComponent<BystanderMovement>();
        if(byStander != null)
            byStander.SetAlive(false);

        StartCoroutine(Die());

        _sceneController.ReSpawn();
       
    }

    private IEnumerator Die()
    {
        if (this.gameObject.tag == "mutant2")
            _anim.SetBool("dieM2", true);

        else if (this.gameObject.tag == "mutant")
            _anim.SetBool("isDying", true);

        else
        {
            GetComponent<BystanderMovement>().enabled = false;
            GetComponent<WanderingAI>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            _anim.SetBool("byStanderDead", true);
        }

        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}