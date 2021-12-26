using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController playerScript;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
       if (playerScript.gameStart) animator.SetBool("onRun", true);
    }
}
