using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftHandler : MonoBehaviour
{
    int speed; //Player speed controller
    PlayerController playerScript;


    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerScript.gameWon || playerScript.gameLose) return;

        speed = playerScript.getSpeed();
        if (gameObject.CompareTag("Enemy") && speed != 0)
            gameObject.transform.Translate(Vector3.forward * (2*speed) * Time.deltaTime); // f(speed) = 2 * speed for enemy
        
        if (gameObject.CompareTag("Friend"))       
            gameObject.transform.Translate(Vector3.back * Mathf.Max((speed - 5), 0) * Time.deltaTime); // f(speed) = speed - 5 for friend
        
        else 
            gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
