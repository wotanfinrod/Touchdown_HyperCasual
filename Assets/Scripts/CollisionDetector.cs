using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] GameObject UIFill;
    PlayerController playerScript;
    SpawnManager spawnManager;

    float progressBar;

    void Start()
    {
        progressBar = 0;
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
            playerScript.GameLose();

        else if (other.gameObject.CompareTag("Chunk")) //If player enters a new chunk
        {
            progressBar += 0.05555555556f;
            UIFill.transform.DOScaleX(progressBar, 1f);
            spawnManager.PoolChunk();
            spawnManager.PoolEnemy();
        }

        else if (other.gameObject.CompareTag("EndChunk"))        
            playerScript.GameWon();
    }
}
