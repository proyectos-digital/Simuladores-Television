using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [Header ("C�maras")]
    public GameObject camaraPrincipal;
    public GameObject camaraAuxiliar;
    public GameObject camaraJugador;
    public GameObject panelCentral;
    public GameObject panelEdicion;
    public GameObject panelInfo;

    private PlayerController playerController;
    public GameObject controllerP;
    private void Start()
    {
        playerController = controllerP.GetComponent<PlayerController>();
    }

    public void CamActriz()
    {
        camaraPrincipal.SetActive(true);
        camaraAuxiliar.SetActive(false);
        camaraJugador.SetActive(false);
        panelCentral.SetActive(false);
    }

    public void CamLateral()
    {
        camaraPrincipal.SetActive(false);
        camaraAuxiliar.SetActive(true);
        camaraJugador.SetActive(false);
        panelCentral.SetActive(false);
    }

    public void CamJugador()
    {
        camaraPrincipal.SetActive(true);
        camaraAuxiliar.SetActive(false);
        camaraJugador.SetActive(true);
        panelCentral.SetActive(true);
    }

    public void AbrirCamara()
    {
        panelEdicion.SetActive(true);
        panelInfo.SetActive(false);
        playerController.enabled = false;
    }
    public void VolverPanel()
    {
        panelEdicion.SetActive(false);
        panelInfo.SetActive(true);
        playerController.enabled = true;
    }
}