using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image barLoading;
    AsyncOperation operationBar;
    public GameManager gameManager;

    //Para cargar las demás escenas.
    public void LoadCases(string nameScene)
    {
        StartCoroutine(SceneLoad(nameScene));
    }

    //Para cargar los dos escenarios de nosferatu
    public void LoadEnvironment(int scenery)
    {
        switch(scenery)
        {
            case 0:
                StartCoroutine(SceneLoad("01-Nosferatu"));
                gameManager.PresionarBtn1();
                break;

            case 1:
                StartCoroutine(SceneLoad("01-Nosferatu"));
                gameManager.PresionarBtn2();
                break;
        }
    }

    IEnumerator SceneLoad(string nameScene)
    {
        operationBar = SceneManager.LoadSceneAsync(nameScene);
        while(!operationBar.isDone)
        {
            barLoading.fillAmount = operationBar.progress;
            yield return null;
        }
    }
}
