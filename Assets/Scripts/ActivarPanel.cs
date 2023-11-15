using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarPanel : MonoBehaviour
{   
    [Header ("Paneles")]
    public GameObject canvasEditarElm;
    private InstanciarElementos inAccesorios;
    private PlayerController playerController;

    void Start()
    {
        canvasEditarElm.SetActive(false);
        inAccesorios = GameObject.FindWithTag("btnInstancia").GetComponent<InstanciarElementos>();
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvasEditarElm.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasEditarElm.SetActive(false);
    }

    public void EliminarAccesorio(int accesorioElim)
    {
        switch (accesorioElim)
        {
            case 0:
                Destroy(gameObject);
                inAccesorios.cantLuminaria++;
                inAccesorios.txtCantLuminaria.text = "" + inAccesorios.cantLuminaria;
                playerController.LockCursor();
                break;

            case 1:
                Destroy(gameObject);
                inAccesorios.cantAperture300++;
                inAccesorios.txtCantAperture300.text = "" + inAccesorios.cantAperture300;
                playerController.LockCursor();
                break;

            case 2:
                Destroy(gameObject);
                inAccesorios.cantSennheiser++;
                inAccesorios.txtCantSennheiser.text = "" + inAccesorios.cantSennheiser;
                playerController.LockCursor();
                break;

            case 3:
                Destroy(gameObject);
                inAccesorios.cantNeewer660++;
                inAccesorios.txtCantNeewer660.text = "" + inAccesorios.cantNeewer660;
                playerController.LockCursor();
                break;

            case 4:
                Destroy(gameObject);
                inAccesorios.cantGodox++;
                inAccesorios.txtCantGodox.text = "" + inAccesorios.cantGodox;
                playerController.LockCursor();
                break;
        }
    }
}
