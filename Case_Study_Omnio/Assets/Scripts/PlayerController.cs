using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameStart;
    public bool gameFinished;

    int playerSpeed;

    Animator animator;
    GameObject mainCamera;
    SpawnManager spawnManager;

    void Start()
    {
        gameStart = false;
        gameFinished = false;

        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        mainCamera = GameObject.Find("Main Camera");
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Key is pressed.
        {
            gameStart = true;

            animator.SetBool("gameStart", true);
            playerSpeed = 10;
            gameObject.transform.DOMoveX(-3f, 0.5f);
            mainCamera.transform.DOMove(new Vector3(-3f, 6.49600029f, -8.76000023f), 0.5f);
        }

        else if (Input.GetKeyUp(KeyCode.Space)) //Key is not pressed anymore.
        {
            playerSpeed = 5;
            gameObject.transform.DOMoveX(+3f, 0.5f);
            mainCamera.transform.DOMove(new Vector3(+3f, 4.49600029f, -6.76000023f), 0.5f);
        }

    }

    //Getters-Setters
    public int getSpeed() { return playerSpeed; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chunk")) //If player enters a new chunk
        {
            spawnManager.PoolChunk();
            spawnManager.PoolEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameFinished = true;
        }
    }


}



