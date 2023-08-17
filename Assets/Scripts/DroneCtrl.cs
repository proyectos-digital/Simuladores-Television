using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCtrl : MonoBehaviour
{
    [Header("Propiedades del Dron")]
    public GameObject dron;
    public Transform posicionDron;
    public bool camDronAct = false;
    public float velMovimiento;
    public float velRotacion;
    public float limitePerimetro;
    public float alturaMax = 5f;
    public float velocidad = 2f;
    public Animator animator;
    private bool enDespegue = false;
    private bool enAterrizaje = false;
    private Vector3 posicionInicial;
    
    [Header("Cámaras")]
    public Camera camaraPrincipal;
    public Camera camaraGrabacion;

    [Header("Referencias al jugador")]
    public GameObject player;
    public Transform posicionJugador;
    public Transform mano;
    private Transform padreOriginal;
    
    [Header("Paneles")]
    public GameObject panelInfo;
    public GameObject panelConfi;
    public GameObject btnCerrar;

    [Header("Controladores")]
    public DroneCtrl dronController;
    private PlayerController playerController;

    void Start()
    {
        dronController = GetComponent<DroneCtrl>();
        playerController = player.GetComponent<PlayerController>();
        dronController.enabled = false;
    }

    void Update()
    {
        ControlDron();

        posicionInicial = mano.position;                                        //Actualizamos la posición inicial en cada cuadro

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
                dron.transform.rotation = mano.rotation;
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

        //Límites del área para el movimiento del dron
       /* nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, -limitePerimetro, limitePerimetro);
        nuevaPosicion.z = Mathf.Clamp(nuevaPosicion.z, -limitePerimetro, limitePerimetro);*/

        transform.position = nuevaPosicion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            panelInfo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panelInfo.SetActive(false);
    }
    public void ModoCamara()
    {
        if (camDronAct)
            return;

        padreOriginal = camaraPrincipal.transform.parent;

        camaraPrincipal.transform.position = posicionDron.position;
        camaraGrabacion.transform.position = posicionDron.position;

        camaraPrincipal.transform.rotation = posicionDron.rotation;
        camaraGrabacion.transform.rotation = posicionDron.rotation;

        camDronAct = true;

        camaraPrincipal.transform.SetParent(posicionDron);
        camaraGrabacion.transform.SetParent(posicionDron);

        panelConfi.SetActive(true);
        panelInfo.SetActive(false);
        playerController.enabled = false;
    }
    public void ModoJuego()
    {
        if (!camDronAct)
            return;

        camaraPrincipal.transform.SetParent(posicionJugador);
        camaraGrabacion.transform.SetParent(posicionJugador);
        camDronAct = false;
        panelInfo.SetActive(true);
        panelConfi.SetActive(false);
        playerController.enabled = true;
    }
}