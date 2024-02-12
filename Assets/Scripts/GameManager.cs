using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject nosferatu;
    public GameObject estudio;
    public AudioListener audioListener;

    public static bool btn1 = true;
    void Start()
    {
        ActivateScene();
    }

    public void ActivateScene()
    {
        if (btn1)
        {
            nosferatu.SetActive(true);
            audioListener.enabled = false;
            estudio.SetActive(false);
        }
        else
        {
            nosferatu.SetActive(false);
            estudio.SetActive(true);
            audioListener.enabled = true;
        }
    }    

    public void PresionarBtn1()
    {
        btn1 = true;
    }

    public void PresionarBtn2()
    {
        btn1 &= false;
    }
}
