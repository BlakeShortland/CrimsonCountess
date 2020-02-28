/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using UnityEngine;
using VRTK;

public class SnapDropZoneLocker : MonoBehaviour
{
	VRTK_SnapDropZone mySDZ;
	VRTK_InteractableObject myInteractableObject;

	void Start()
	{
		mySDZ = GetComponent<VRTK_SnapDropZone>();
	}

	public void SetObjectToSnap()
	{
		myInteractableObject = mySDZ.GetCurrentSnappedInteractableObject();

		mySDZ.defaultSnappedInteractableObject = myInteractableObject;
	}

	public void Deletus()
	{
		Destroy(gameObject);
	}
}
