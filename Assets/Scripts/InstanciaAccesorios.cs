using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstanciaAccesorios : MonoBehaviour
{
    public GameObject objetoPrefab;
    public Transform mano;
    public int cantidadObjetos = 10;
    public TMP_Text aviso;

    void Start()
    {
        aviso.text = "" + cantidadObjetos;
    }

    public void NuevoObjeto()
    {
        if(cantidadObjetos > 0)
        {
            Instantiate(objetoPrefab, mano.transform.position, mano.transform.rotation);
            cantidadObjetos--;
            aviso.text = "" + cantidadObjetos;
        }
    }
}
