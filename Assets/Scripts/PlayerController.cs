using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [Header ("UI")]
    public CharacterController characterController;
    public TMP_InputField inputKeyUp;
    public TMP_InputField inputKeyDown;
    public TMP_InputField inputKeyRight;
    public TMP_InputField inputKeyLeft;
    
    [Header ("Speed")]
    public float moveSpeed;
    public float mouseSensitivy;
    
    private float verticalRotation;
    private KeyCode keyUp;
    private KeyCode keyDown;
    private KeyCode keyRight;
    private KeyCode keyLeft;
    private bool saveKeys;

    void Start()
    {
        saveKeys = false;
        LockCursor();
    }

    void Update()
    {
        MoveCam();
        UnlockCursor();

        if(saveKeys == true)
        {
            ModifiedMovement();
        }
        else
        {
            DefaultMovement();
        }
    }

    public void ModifiedMovement()
    {
        SaveKeys();
        float forwardSpeed = 0f;
        float sideSpeed = 0f;

        if (Input.GetKey(keyUp))
        {
            forwardSpeed = moveSpeed;
        }
        else if(Input.GetKey(keyDown))
        {
            forwardSpeed = -moveSpeed;
        }
        else if (Input.GetKey(keyRight))
        {
            sideSpeed = moveSpeed;
        }
        else if (Input.GetKey(keyLeft))
        {
            sideSpeed = -moveSpeed;
        }

        Vector3 movement = transform.forward * forwardSpeed + transform.right * sideSpeed;
        movement = transform.rotation * movement;
        characterController.SimpleMove(movement);
    }

    private void SaveKeys()
    {
        keyUp = (KeyCode)Enum.Parse(typeof(KeyCode), inputKeyUp.text[0].ToString().ToUpper());
        keyDown = (KeyCode)Enum.Parse(typeof(KeyCode), inputKeyDown.text[0].ToString().ToUpper());
        keyRight = (KeyCode)Enum.Parse(typeof(KeyCode), inputKeyRight.text[0].ToString().ToUpper());
        keyLeft = (KeyCode)Enum.Parse(typeof(KeyCode), inputKeyLeft.text[0].ToString().ToUpper());
        saveKeys = true;
    }
    public void DefaultMovement()
    {
        saveKeys = false;
        CleanInput();
        float forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;
        characterController.SimpleMove(speed);
    }

    public void CleanInput()
    {
        inputKeyUp.text = "";
        inputKeyDown.text = "";
        inputKeyRight.text = "";
        inputKeyLeft.text = "";
    }
   
    private void MoveCam()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivy;
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivy;
        verticalRotation = Mathf.Clamp(verticalRotation, -30, 30);
        transform.Rotate(0, horizontalRotation, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    //Desactivar cuando se entre en inventario o config
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Activar cuando se entre en inventario o config
    public void UnlockCursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}