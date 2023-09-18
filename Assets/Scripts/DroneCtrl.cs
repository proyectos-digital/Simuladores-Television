using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCtrl : MonoBehaviour
{
    [Header("Propiedades del Dron")]
    public bool camDronAct = false;
    public float velMovimiento;
    public float velRotacion;
    public float alturaMax;
    public float velocidad;
    public Animator animator;
    //public GameObject dron;

    private bool enDespegue = false;
    private bool enAterrizaje = false;
    private Vector3 posicionInicial;
    
    [Header("Cámaras")]
    public Camera camaraPrincipal;

    [Header("Controladores")]
    public DroneCtrl dronController;
    public PlayerController playerController;

    [Header ("Posición de elementos")]
    public Transform posicionCamOriginal;
    public Transform puntoAterrizaje;
    public Transform posicionDron;
    private Transform padreOriginal;
    //public Transform mano;

    [Header("UI")]
    public GameObject panelInfo;
    public GameObject panelConfi;
    public GameObject btnCerrar;

    void Start()
    {
        dronController = GetComponent<DroneCtrl>();
        dronController.enabled = false;
        posicionInicial = puntoAterrizaje.position;
    }

    void Update()
    {
        ControlDron();

       //posicionInicial = mano.position;                                        //Actualizamos la posición inicial en cada cuadro

        if (enDespegue)
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);       //Se desplaza hacia arriba hasta la altura máxima
            if (transform.position.y - posicionInicial.y >= alturaMax)           //Verifica si ha alcanzado la altura máxima
            {
                enDespegue = false;
            }
        }

        else if (enAterrizaje)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);     //Desciende hacia el punto inicial
            if (transform.position.y <= posicionInicial.y)                       //Verifica si ha alcanzado o pasado la posición inicial
            {
                enAterrizaje = false;
                transform.position = posicionInicial;
                //dron.transform.rotation = mano.rotation;
                //camaraPrincipal.transform.rotation = dron.transform.rotation;
            }
        }

        if (camDronAct == true)
        {
            panelInfo.SetActive(false);
            animator.Play("blade");
        }
    }

    public void Despegue()
    {
        enDespegue = true;
        enAterrizaje = false; 
        dronController.enabled = true;
        btnCerrar.SetActive(false);
    }

    public void Aterrizaje()
    {
        enAterrizaje = true;
        enDespegue = false;
        StartCoroutine("FinVuelo");
    }

    IEnumerator FinVuelo()
    {
        yield return new WaitForSeconds(3f);
        dronController.enabled = false;
        btnCerrar.SetActive(true);
    }

    public void ControlDron()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Rotacion del dron
        float valorRotacion = horizontalInput * velRotacion * Time.deltaTime;
        transform.Rotate(Vector3.up, valorRotacion);

        Vector3 redireccion = transform.forward;

        Vector3 movimiento = redireccion * verticalInput * velMovimiento * Time.deltaTime;
        Vector3 nuevaPosicion = transform.position + movimiento;

        transform.position = nuevaPosicion;
    }

    public void ModoCamara()
    {
        if (camDronAct)
            return;

        //Asignamos la cámara al Dron en su posición y rotación
        padreOriginal = camaraPrincipal.transform.parent;
        camaraPrincipal.transform.position = posicionDron.position;
        camaraPrincipal.transform.rotation = posicionDron.rotation;
        camaraPrincipal.transform.SetParent(posicionDron);

        camDronAct = true;
        panelConfi.SetActive(true);
        panelInfo.SetActive(false);
        playerController.enabled = false;
    }
    public void ModoJuego()
    {
        if (!camDronAct)
            return;

        //Asignamos la cámara al jugador en su posición y rotación
        camaraPrincipal.transform.SetParent(posicionCamOriginal);
        camaraPrincipal.transform.position = posicionCamOriginal.position;
        camaraPrincipal.transform.rotation = posicionCamOriginal.rotation;

        camDronAct = false;
        panelInfo.SetActive(true);
        panelConfi.SetActive(false);
        playerController.enabled = true;
        playerController.LockCursor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelInfo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panelInfo.SetActive(false);
    }
}