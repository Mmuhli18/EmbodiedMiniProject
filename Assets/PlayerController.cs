using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float movementSpeed = 1;
    private float liftSpeed = 1000f;
    private Vector3 playerVelocity;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!characterController.enabled) { return; }

        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;

        playerVelocity.y = 0f;

            playerVelocity.y -= liftSpeed * Time.deltaTime;


        characterController.Move((transform.right * horizontal + transform.forward * vertical + playerVelocity) * Time.deltaTime);
    }
}
