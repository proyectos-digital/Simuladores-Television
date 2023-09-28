using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VideoRecord : MonoBehaviour
{
    public GameObject[] uiDesact;
    public GameObject[] uiActiv;
    private float tiempo;
    private bool tiempoCorriendo;
    public TMP_Text txtTiempo;
    public PlayerController plCtrl;
    void Update()
    {
        if (tiempoCorriendo)
        {
            tiempo += Time.deltaTime;
            txtTiempo.text = "" + tiempo.ToString("F2");
        }
    }

    public void StartRecord()
    {
        tiempoCorriendo = true;

        for (int i = 0; i < uiActiv.Length; i++)
        {
            uiActiv[i].gameObject.SetActive(true);
        }

        for(int i= 0 ; i < uiDesact.Length; i++)
        {
            uiDesact[i].gameObject.SetActive(false);
        }
    }
    
    public void StopRecord()
    {

        for (int i = 0; i < uiActiv.Length; i++)
        {
            uiActiv[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < uiDesact.Length; i++)
        {
            uiDesact[i].gameObject.SetActive(true);
        }
        tiempoCorriendo = false;
        txtTiempo.text = "";
        tiempo = 0f;                            //Reinicia el tiempo
        plCtrl.LockCursor();
    }
}
