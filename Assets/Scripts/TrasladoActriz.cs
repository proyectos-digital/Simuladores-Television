using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasladoActriz : MonoBehaviour
{
    [Header ("Animaciones")]
    public Animator animator;
    public string animReaccion;
    public string animCaminar;
    public string animIdle;

    [Header ("Traslados")]
    public float velocidad;
    public Transform puntoA;
    public Transform puntoB;
    public bool caminando = false;

    void Update()
    {
        PuntoFinalTraslado();
    }

    //Del punto A al B
    public void PuntoFinalTraslado()
    {
        if (caminando)
        {
            Vector3 direccion = (puntoB.position - puntoA.position).normalized;

            float distancia = Vector3.Distance(transform.position, puntoB.position);

            transform.position += direccion * velocidad * Time.deltaTime;

            if (distancia <= velocidad * Time.deltaTime)
            {
                transform.position = puntoB.position;
                caminando = false;
                animator.Play(animReaccion);
            }
        }
    }

    public void InicioActuar()
    {
        caminando = true;
        animator.Play(animCaminar);
    }

    public void RetornoEscena()
    {
        caminando = false;
        animator.Play(animIdle);
        transform.position = puntoA.position;
    }
}
