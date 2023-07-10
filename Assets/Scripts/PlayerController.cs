using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Valores")]
    public float walkSpeed;
    public float rotateSpeed;
    float x;
    float y;

    void Update()
    {
        Move();
    }

    void Move()
    {
        //Toma la entrada de teclado
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotateSpeed, 0);
        transform.Translate(0,0, y * Time.deltaTime * walkSpeed);
    }
}