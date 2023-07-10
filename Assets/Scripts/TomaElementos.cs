using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaElementos : MonoBehaviour
{
    public GameObject elementos;            //El elemento que tomaré
    private Transform posicionElemento;     //Mano
    private bool activ;                     //Para saber cuando estoy dentro o fuera de la zona del objeto

    private void Start()
    {
        GameObject objetoMano = GameObject.FindWithTag("Mano");

        if(objetoMano != null )
        {
            posicionElemento = objetoMano.transform;
        } else
        {
            Debug.LogWarning("No se encontró ningún objeto con la etiqueta Mano.");
        }
    }
    void Update()
    {
        TomaElemento();
    }

    public void TomaElemento()
    {
        if (activ == true)
        {
            //Toma el elemento
            if (Input.GetKeyDown(KeyCode.Q))
            {
                elementos.transform.SetParent(posicionElemento);            //El elemento se colocará dentro del objeto que esta en el player
                elementos.transform.position = posicionElemento.position;   //Le digo que el elemento debe quedar en la misma posición que el padre
                Debug.Log("Soltó");

            }

            //Suelta el elemento
            if (Input.GetKeyDown(KeyCode.E))
            {
                elementos.transform.SetParent(null);
                Debug.Log("Soltó");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            activ = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player")
        {
            activ = false;
        }
    }
}