using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    BuildManager buildManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Turret"))
        {
            buildManager.canPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Turret"))
        {
            buildManager.canPlace = true;
        }
    }
    void Start()
    {
        buildManager = GameObject.Find("BuildManager").GetComponent<BuildManager>();

    }

}
