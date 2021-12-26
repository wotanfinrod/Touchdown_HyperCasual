using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<GameObject> ragdollComponents;
    [SerializeField] GameObject UIbutton;
    [SerializeField] GameObject UIGameOver;


    public bool gameStart;
    public bool gameWon;
    public bool gameLose;

    int playerSpeed;

    Animator animator;
    GameObject mainCamera;
    SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        mainCamera = GameObject.Find("Main Camera");
        animator = gameObject.GetComponent<Animator>();

        DisableRagdolls();
        gameStart = gameWon = gameLose = false;
        UIbutton.SetActive(false);
        UIGameOver.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameWon && !gameLose) //Key is pressed.
        {
            gameStart = true;

            animator.SetBool("gameStart", true);
            playerSpeed = 10;
            gameObject.transform.DOMoveX(-2f, 0.5f);
            mainCamera.transform.DOMove(new Vector3(-2f, 6.49600029f, -8.76000023f), 0.5f);
        }

        else if (Input.GetKeyUp(KeyCode.Space) && !gameWon && !gameLose) //Key is not pressed anymore.
        {
            playerSpeed = 5;
            gameObject.transform.DOMoveX(+2f, 0.5f);
            mainCamera.transform.DOMove(new Vector3(+2f, 4.49600029f, -6.76000023f), 0.5f);
        }

    }

    public void GameWon()
    {
        gameWon = true;
        gameObject.transform.DOMoveZ(gameObject.transform.position.z + 4f, 1f);
        animator.SetInteger("gameWonState", Random.Range(1, 4));
        playerSpeed = 0;

        mainCamera.transform.DOMoveZ(mainCamera.transform.position.z - 3f, 1.5f);
        mainCamera.transform.DOMoveY(mainCamera.transform.position.y + 2f, 1.5f);

        UIbutton.SetActive(true);
        UIGameOver.SetActive(true);
    } 
    void DisableRagdolls()
    {
        foreach (GameObject obj in ragdollComponents)
        {
            Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
            if (!(obj.name == "mixamorig:Spine")) rigidbody.isKinematic = true;
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            rigidbody.useGravity = false;
        }
    }

    void EnableRagdolls()
    {
        foreach (GameObject obj in ragdollComponents) //Enable ragdoll components
        {
            Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.useGravity = true;
        }
    }

    public void GameLose()
    {
        gameLose = true;
        playerSpeed = 0;
        animator.enabled = false;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        mainCamera.transform.DOMoveZ(mainCamera.transform.position.z - 3f, 1.5f);
        mainCamera.transform.DOMoveY(mainCamera.transform.position.y + 2f, 1.5f);

        UIbutton.SetActive(true);
        UIGameOver.SetActive(true);
        
        EnableRagdolls();   
    }
    
    public void UIButtonClick()
    {
        SceneManager.LoadScene(0);
    } 
    //Getters-Setters
    public int getSpeed() { return playerSpeed; }
}



