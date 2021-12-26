using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    int chunkCount;

    [SerializeField] GameObject endChunk;

    Queue<GameObject> chunkQueue;
    Queue<GameObject> enemyQueue;
    Queue<GameObject> friendQueue;
    Vector3 chunkSpawnLocation = new Vector3(0, 0, 109.7932f);
    Vector3 enemySpawnLocation = new Vector3(-2f, 0, 107.050003f);

    void Start()
    {
        endChunk.SetActive(false);

        //ChunkPool
        chunkQueue = new Queue<GameObject>();
        for (int i = 1; i <= 12; i++)
            chunkQueue.Enqueue(GameObject.Find("Chunk" + i));

        //EnemyPool
        enemyQueue = new Queue<GameObject>();
        for (int i = 1; i <= 22; i++)
            enemyQueue.Enqueue(GameObject.Find("Enemy" + i));

        //FriendPool
        friendQueue = new Queue<GameObject>();
        for (int i = 1; i <= 4; i++ )
        {
            friendQueue.Enqueue(GameObject.Find("Friend" + i));
        }
    }


    public void PoolChunk()
    {
        if (endChunk.activeSelf) return; //Stop generating chunks if ending chunk is on

        if(chunkCount >= 6 ) //Generate the level end
        {
            endChunk.transform.position = chunkSpawnLocation;
            endChunk.SetActive(true);
            return;
        }
           
        chunkCount++;
        GameObject currentChunk = chunkQueue.Dequeue();
        currentChunk.transform.position = chunkSpawnLocation;
        chunkQueue.Enqueue(currentChunk);
        
    }

    //Everytime player passes chunk; 0, 1 or 2 enemies will be spawned with the new chunk. 
    public void PoolEnemy()
    {
        List<GameObject> currentEnemies = new List<GameObject>();

        int enemyNumber = Random.Range(0, 3);
        for (int i = 0; i < enemyNumber; i++)
            currentEnemies.Add(enemyQueue.Dequeue());
        
        int zOffset = 0; 

        foreach (GameObject enemy in currentEnemies)
        {
            enemy.transform.position = new Vector3(enemySpawnLocation.x, enemySpawnLocation.y, enemySpawnLocation.z + zOffset);
            zOffset += 3;
            enemyQueue.Enqueue(enemy);
        }
        currentEnemies.Clear();
    }
}
