using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header ("Cámaras")]
    public GameObject camaraPrincipal;
    public GameObject camaraAuxiliar;
    public GameObject camaraJugador;

    [Header("UI")]
    public GameObject panelCentral;
    public GameObject panelEdicion;
    public GameObject panelInfo;

    [Header ("Jugador")]
    public PlayerController playerController;
    public void ManejoCamaras(int caso)
    {
        switch (caso)
        {
            case 0: //Cam Principal
                camaraPrincipal.SetActive(true);
                camaraAuxiliar.SetActive(false);
                camaraJugador.SetActive(false);
                panelCentral.SetActive(false);
                break;

            case 1: //Cam Auxiliar
                camaraPrincipal.SetActive(false);
                camaraAuxiliar.SetActive(true);
                camaraJugador.SetActive(false);
                panelCentral.SetActive(false);
                break;

            case 2: //Volver a cámara del jugador
                camaraPrincipal.SetActive(true);
                camaraAuxiliar.SetActive(false);
                camaraJugador.SetActive(true);
                panelCentral.SetActive(true);
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