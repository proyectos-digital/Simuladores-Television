using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image barLoading;
    AsyncOperation operationBar;

    public void LoadScene(string name)
    {
        StartCoroutine(LoadSce(name));
    }

    IEnumerator LoadSce(string name)
    {
        operationBar = SceneManager.LoadSceneAsync(name);
        while(!operationBar.isDone)
        {
            barLoading.fillAmount = operationBar.progress;
            yield return null;
        }
    }
}
