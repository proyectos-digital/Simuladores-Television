using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float mouseSensitivy;

    private float verticalRotation;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        LockCursor();
    }

    private void Update()
    {
        MovePlayer();
        MoveCam();
        UnlockCursor();
    }

    public void MovePlayer()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;

        characterController.SimpleMove(speed);
    }

    public void MoveCam()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivy;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivy;

        verticalRotation = Mathf.Clamp(verticalRotation, -30, 30);

        transform.Rotate(0, horizontalRotation, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}