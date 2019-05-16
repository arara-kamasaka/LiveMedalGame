using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    public int Value;

    public void Get()
    {
        Destroy(Instantiate(effect, transform.position, transform.rotation), 2.0f);
    }

}
