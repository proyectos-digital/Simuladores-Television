using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationCamDron : MonoBehaviour
{
    public Slider sliderRotacion;
    public float limiteSuperior = 35f;
    public float limiteInferior = -35f;
    void Update()
    {
        RotacionCam();
    }
    public void RotacionCam()
    {
        float valorSlider = sliderRotacion.value;
        valorSlider = Mathf.Clamp(valorSlider, limiteInferior, limiteSuperior);
        float rotacionX = valorSlider;
        transform.eulerAngles = new Vector3(rotacionX, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
