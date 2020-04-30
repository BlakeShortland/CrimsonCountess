using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HandBleed : MonoBehaviour
{
    [SerializeField] GameObject bloodSpurt;

    bool isBleeding = false;

    bool isOn = false;

	public void TurnOn()
    {
        isOn = true;
    }

    public void TurnOff()
    {
        isOn = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ItemKnife")
        {
            if (!isBleeding && isOn)
            {
                isBleeding = true;
                //print(collider.gameObject);
                GameObject bloodSpurtFX = Instantiate(bloodSpurt, transform.position, Quaternion.identity, transform);
                bloodSpurtFX.transform.up = transform.up;
            }
        }
    }
}
