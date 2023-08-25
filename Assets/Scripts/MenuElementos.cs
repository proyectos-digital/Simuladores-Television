using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuElementos : MonoBehaviour
{
    [Header ("Activación de páneles")]
    public GameObject panelMenu;
    public GameObject panelLuces;
    public GameObject panelMicrofonos;
    public GameObject panelControles;
    public GameObject panelGrabacion;

    private bool panelActivo;
    public void ActivarMenu()
    {
        panelActivo = !panelActivo;
        panelMenu.SetActive(panelActivo);
        if(panelActivo == false)
        {
            panelLuces.SetActive(false);
            panelMicrofonos.SetActive(false);
            panelControles.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    public void ActivarPanelLuces()
    {
        panelLuces.SetActive(true);
        panelMicrofonos.SetActive(false);
        panelControles.SetActive(false);
    }

    public void ActivarPanelMicroofonos()
    {
        panelLuces.SetActive(false);
        panelMicrofonos.SetActive(true);
        panelControles.SetActive(false);
    }

    public void ActivarControles()
    {
        panelLuces.SetActive(false);
        panelMicrofonos.SetActive(false);
        panelControles.SetActive(true);
    }

    public void ActivarPanelGrabacion()
    {
        panelActivo = !panelActivo;
        panelGrabacion.SetActive(panelActivo);
        if (panelActivo == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}