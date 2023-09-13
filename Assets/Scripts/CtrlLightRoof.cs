using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlLightRoof : MonoBehaviour
{
    [Header("Luces superiores")]
    public GameObject pnlLuces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pnlLuces.SetActive(true);
            Debug.Log("Desde luces");
        }
    }
}
