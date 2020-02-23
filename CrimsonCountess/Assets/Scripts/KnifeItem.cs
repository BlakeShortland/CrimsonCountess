using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeItem : MonoBehaviour
{
	[SerializeField] GameObject bloodSpurt;

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "RightController" || collision.gameObject.tag == "LeftController")
		{
			ContactPoint firstContactPoint = collision.contacts[0];
			GameObject bloodSpurtFX = Instantiate(bloodSpurt, firstContactPoint.point, Quaternion.identity);
			bloodSpurtFX.transform.up = firstContactPoint.normal;
		}
	}
}
