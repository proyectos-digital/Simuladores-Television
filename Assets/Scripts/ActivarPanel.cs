using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarPanel : MonoBehaviour
{   
    [Header ("Paneles")]
    public GameObject canvasEditarElm;
    InstanciaAccesorios inAccesorios;
    
    void Start()
    {
        canvasEditarElm.SetActive(false);
        inAccesorios = GameObject.FindWithTag("btnInstancia").GetComponent<InstanciaAccesorios>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canvasEditarElm.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        canvasEditarElm.SetActive(false);
    }

    public void Eliminar()
    {
        Destroy(gameObject);
        inAccesorios.cantidadObjetos++;
        inAccesorios.aviso.text = "" + inAccesorios.cantidadObjetos;
    }
}
