using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarPanel : MonoBehaviour
{   
    [Header ("Paneles")]
    public GameObject canvasEditarElm;
    //InstanciaAccesorios inAccesorios;
    
    private GameObject canvasPrincipal;

    void Start()
    {
        //inAccesorios = GameObject.FindWithTag("BtnIntancia").GetComponent<InstanciaAccesorios>();
        
        GameObject canvasP = GameObject.FindWithTag("CvPrincipal");

        if (canvasP != null)
        {
            canvasPrincipal = canvasP;
        }
        else
        {
            Debug.LogWarning("No se encontró ningún objeto con la etiqueta CvPrincipal.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canvasEditarElm.SetActive(true);
        canvasPrincipal.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        canvasEditarElm.SetActive(false);
        canvasPrincipal.SetActive(true);
    }

    public void Eliminar()
    {
        Destroy(gameObject);
        //inAccesorios.cantidadObjetos++;
        //inAccesorios.aviso.text = "" + inAccesorios.cantidadObjetos;
        canvasPrincipal.SetActive(true);
    }
}
