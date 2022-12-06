using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController charControl;
    private Vector3 direction;
    public float speed;

    private int presentLane = 2; // left = 1, middle = 2, right = 3;
    public float distanceBetweenLanes = 4;
    public float jumpForce;
    public float g = -20;

    void Start()
    {
        charControl = GetComponent<CharacterController>();        
    }

    // Update is called once per frame
    void Update()
    {   
        direction.z = speed;

        if (charControl.isGrounded){
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                Jump();
            }
        } else {
            direction.y += g * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow)){
            presentLane ++;

            if (presentLane == 4){
                presentLane = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            presentLane --;

            if (presentLane == 0){
                presentLane = 1;
            }
        }

        Vector3 goToPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (presentLane == 1){
            goToPosition += Vector3.left * distanceBetweenLanes;
        } else if (presentLane == 3){
            goToPosition += Vector3.right * distanceBetweenLanes;
        }

        transform.position = goToPosition;
        charControl.center = charControl.center;

    }

    private void FixedUpdate(){
        charControl.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump(){
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.transform.tag == "Obstacle"){
            PlayerManager.gameOver = true;
        }
    }
}

