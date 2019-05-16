using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedalChecker : MonoBehaviour
{
    [SerializeField] private MedalProvider medalProvider;
    [SerializeField] private Material[] materials;

    private void OnTriggerEnter(Collider other)
    {
        medalProvider.Check();
        GetComponent<Renderer>().material = materials[0];
    }
    
    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material = materials[1];
    }
}
