using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlickerLight : MonoBehaviour
{

    SphereCollider collider;

    public UnityEvent StartFlicker;
    public UnityEvent StopFlicker;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();

        if (StartFlicker == null)
            StartFlicker = new UnityEvent();

        if (StopFlicker == null)
            StopFlicker = new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartFlicker.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        StopFlicker.Invoke();
    }
}
