using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header ("Cámaras")]
    public Camera camPrincipal;
    public Camera camAuxiliar;
    public Camera camJugador;

    [Header("UI")]
    public GameObject panelCentral;
    public GameObject panelEdicion;
    public GameObject panelInfo;
    public GameObject PanelDia;

    [Header ("Jugador")]
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelDia.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PanelDia.SetActive(true);
        playerController.LockCursor();
        ManejoCamaras(4);
    }
    public void ManejoCamaras(int caso)
    {
        switch (caso)
        {
            case 0: //Cam Principal
                camPrincipal.targetDisplay = 0;
                camAuxiliar.targetDisplay = 1;
                camJugador.targetDisplay = 1;
                panelCentral.SetActive(false);
                panelInfo.SetActive(false);
                camPrincipal.targetTexture = null;
                camAuxiliar.targetTexture = null;
                camJugador.targetTexture = null;

                break;

            case 1: //Cam Auxiliar
                camPrincipal.targetDisplay = 1;
                camAuxiliar.targetDisplay = 0;
                camJugador.targetDisplay = 1; 
                panelInfo.SetActive(false);
                panelCentral.SetActive(false);
                camPrincipal.targetTexture = null;
                camAuxiliar.targetTexture = null;
                camJugador.targetTexture = null;
                break;

            case 2: //Volver a cámara del jugador
                camPrincipal.targetDisplay = 1;
                camAuxiliar.targetDisplay = 1;
                camJugador.targetDisplay = 0; 
                playerController.enabled = true;
                panelCentral.SetActive(true);
                camPrincipal.targetTexture = null;
                camAuxiliar.targetTexture = null;
                camJugador.targetTexture = null;
                break;

            case 3: //Abrir la cámara
                panelEdicion.SetActive(true);
                panelInfo.SetActive(false);
                playerController.enabled = false;
                break;

            case 4: //Volver al panel
                panelEdicion.SetActive(false);
                panelInfo.SetActive(true);
                playerController.enabled = true;
                break;
        }
    }
}