using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotacionAltura : MonoBehaviour
{
    public GameObject objeto;
    public Slider rotationSlider;
    public int tipoRotacion;

    private void Start()
    {
        rotationSlider.onValueChanged.AddListener(EdicionObjeto);
    }

    void EdicionObjeto(float value)
    {
        float rotationAmount = value * 360f;

        switch (tipoRotacion)
        {
            case 0:
                objeto.transform.rotation = Quaternion.Euler(rotationAmount, 0f, 0f); //Gira de derecha a izquierda
                break;

            case 1:
                objeto.transform.rotation = Quaternion.Euler(0f, rotationAmount, 0f); //Gira de manera horizontal
                break;
        }
    }
}
