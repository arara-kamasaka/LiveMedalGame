using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class MedalGetter : MonoBehaviour
{
    [SerializeField] private MedalProvider medalProvider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medal"))
        {
            var m = other.GetComponent<Medal>();
            medalProvider.Get(m.Value);
            m.Get();
        }
    }
}