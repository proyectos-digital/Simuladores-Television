using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuElementos : MonoBehaviour
{
    [Header ("Activaci�n de p�neles")]
    public GameObject luces;
    public GameObject microfonos;
    public GameObject panelGrabacion;
    private bool panelActivo;

    public void ActivarPanelLuces()
    {
        luces.SetActive(true);
        microfonos.SetActive(false);
    }

    public void ActivarPanelMicroofonos()
    {
        luces.SetActive(false);
        microfonos.SetActive(true);
    }

    public void ActivarPanelGrabacion()
    {
        panelActivo = !panelActivo;
        panelGrabacion.SetActive(panelActivo);
    }
}