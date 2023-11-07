using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuElementos : MonoBehaviour
{
    [Header ("Ui")]
    public GameObject panelMenu;
    public GameObject panelCamaras;
    public GameObject panelControles;
    public GameObject modificaControles;
    public PlayerController playerController;
    private bool panelActivo = false;

    public void ActivarUI(int panel)
    {
        panelActivo = !panelActivo;
        switch (panel)
        {
            case 0:
                panelMenu.SetActive(panelActivo);
                if (panelActivo == true)
                {
                    playerController.moveSpeed = 0;
                    playerController.mouseSensitivy = 0;
                }
                else
                {
                    playerController.moveSpeed = 5;
                    playerController.mouseSensitivy = 2;
                    playerController.LockCursor();
                }
                break;

            case 1:
                panelCamaras.SetActive(panelActivo);
                break;

            case 2:
                panelControles.SetActive(panelActivo);
                break;

            case 3:
                SceneManager.LoadScene("Menu");
                break;

            case 4:
                modificaControles.SetActive(true);
                panelControles.SetActive(false);
                break;
        }
    }
}