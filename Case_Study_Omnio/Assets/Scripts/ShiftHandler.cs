using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftHandler : MonoBehaviour
{
    int speed;
    PlayerController playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerScript.getSpeed();
        gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
