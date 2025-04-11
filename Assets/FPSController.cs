using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
       public Camera playerCamera;
       public float walkSpeed = 6f;
       public float runSpeed = 12f;
       public float jumpPower = 7f;
       public float gravity = 10f;
    
    
       public float lookSpeed = 2f;
       public float lookXLimit = 45f;
    
    
       Vector3 moveDirection = Vector3.zero;
       float rotationX = 0;
    
       public bool canMove = true;
       public VideoPlayer videoPlayer;
       public GameObject videoPlayerObject;
       public GameObject videoCanvasImages;
       public bool videoPlayerIsPlaying = true;
       public AudioSource audioSource;
       public AudioSource audioSource2;
       CharacterController characterController;
       void Start()
       {
           videoPlayerIsPlaying = true;
           videoPlayer.Play();
           characterController = GetComponent<CharacterController>();
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;
           
           // Set the video player to loop initially
           videoPlayer.loopPointReached += OnVideoLoopPointReached;
       }
    
       void Update()
       {
           if (!videoPlayerIsPlaying)
           {
               
               #region Handles Movement
                 Vector3 forward = transform.TransformDirection(Vector3.forward);
                 Vector3 right = transform.TransformDirection(Vector3.right);
          
                 // Press Left Shift to run
                 bool isRunning = false;
                 float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
                 float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
                 float movementDirectionY = moveDirection.y;
                 moveDirection = (forward * curSpeedX) + (right * curSpeedY);
          
                 #endregion
          
               
          
                 #region Handles Rotation
                 characterController.Move(moveDirection * Time.deltaTime);
          
                 if (canMove)
                 {
                     rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                     rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                     playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                     transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
                 }
          
                 #endregion 
           }
          
       }
       
       void OnVideoLoopPointReached(VideoPlayer vp)
       {
           videoPlayer.Stop();
           Destroy(videoPlayerObject);
           Destroy(videoCanvasImages);
           videoPlayerIsPlaying = false;
           audioSource.Play();
           audioSource2.Play();
           Debug.Log("The video player is not playing anymore.");
       }
}
