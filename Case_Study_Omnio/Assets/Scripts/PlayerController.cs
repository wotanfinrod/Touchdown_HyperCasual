using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    //const float cameraY;
    //const float cameraZ;


    int playerSpeed;
    Vector3 cameraDrag; 

    Animator animator;
    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        animator = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        //Calculating the global position for camera
        Transform cameraTransform = mainCamera.transform;
        Vector3 cameraPos = new Vector3(cameraTransform.position.x + cameraDrag.x, cameraTransform.position.y + cameraDrag.y , cameraTransform.position.z + cameraDrag.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("gameStart", true);
            playerSpeed = 10;
            gameObject.transform.DOMoveX(-3f, 0.5f);
            mainCamera.transform.DOMoveY((mainCamera.transform.position.y) +2f ,0.5f);
            mainCamera.transform.DOMoveZ((mainCamera.transform.position.z) - 2f, 0.5f);
            mainCamera.transform.DORotate(mainCamera.transform.rotation.eulerAngles + new Vector3(5, 0, 0));
        }

        else if(Input.GetKeyUp(KeyCode.Space))
        {
            playerSpeed = 5;
            gameObject.transform.DOMoveX(+3f, 0.5f);
            mainCamera.transform.DOMoveY((mainCamera.transform.position.y) - 2f, 0.5f);
            mainCamera.transform.DOMoveZ((mainCamera.transform.position.z) + 2f, 0.5f);

        }

    }

    //Getters-Setters
    public int getSpeed() { return playerSpeed; }

}
