using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    PlayerController playerScript;
    SpawnManager spawnManager;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            playerScript.GameLose();

        else if (other.gameObject.CompareTag("Chunk")) //If player enters a new chunk
        {
            spawnManager.PoolChunk();
            spawnManager.PoolEnemy();
        }

        else if (other.gameObject.CompareTag("EndChunk"))        
            playerScript.GameWon();
    }
}
