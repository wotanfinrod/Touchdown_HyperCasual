using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public bool gameStart;
    public bool gameFinished;


    int playerSpeed;
    Vector3 cameraDrag; 

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
        //Calculating the global position for camera
        Transform cameraTransform = mainCamera.transform;
        Vector3 cameraPos = new Vector3(cameraTransform.position.x + cameraDrag.x, cameraTransform.position.y + cameraDrag.y , cameraTransform.position.z + cameraDrag.z);

        if (Input.GetKeyDown(KeyCode.Space)) //Key is pressed.
        {
            gameStart = true;

            animator.SetBool("gameStart", true);
            playerSpeed = 10;
            gameObject.transform.DOMoveX(-3f, 0.5f);
            mainCamera.transform.DOMoveY((mainCamera.transform.position.y) +2f ,0.5f);
            mainCamera.transform.DOMoveZ((mainCamera.transform.position.z) - 2f, 0.5f);
        }

        else if(Input.GetKeyUp(KeyCode.Space)) //Key is not pressed anymore.
        {
            playerSpeed = 5;
            gameObject.transform.DOMoveX(+3f, 0.5f);
            mainCamera.transform.DOMoveY((mainCamera.transform.position.y) - 2f, 0.5f);
            mainCamera.transform.DOMoveZ((mainCamera.transform.position.z) + 2f, 0.5f);
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



}



