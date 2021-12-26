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
        speed = playerScript.getSpeed();

        if (gameObject.CompareTag("Enemy"))
        {
            gameObject.transform.Translate(Vector3.back * -2 * speed * Time.deltaTime); //Enemy movement
        }
        if (gameObject.CompareTag("Friend"))
        {
            Debug.Log(speed - 5);
            gameObject.transform.Translate(Vector3.back * Mathf.Max((speed - 5), 0) * Time.deltaTime);
        }
        else gameObject.transform.Translate(Vector3.back * (speed) * Time.deltaTime);
    }
}
