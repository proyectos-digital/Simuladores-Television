using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject nosferatu;
    public GameObject estudio;

    public static bool btn1 = false;
    void Start()
    {
        ActivateScene();
    }

    public void ActivateScene()
    {
        if (btn1)
        {
            nosferatu.SetActive(true);
            estudio.SetActive(false);
        }
        else
        {
            nosferatu.SetActive(false);
            estudio.SetActive(true);
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
