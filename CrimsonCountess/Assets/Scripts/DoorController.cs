using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
	[SerializeField] PosRot openPosRot;
	[SerializeField] PosRot closedPosRot;

	public void OpenDoor()
	{
		transform.localPosition = openPosRot.pos;
		transform.localRotation = openPosRot.rot;
	}

	public void CloseDoor()
	{
		transform.localPosition = closedPosRot.pos;
		transform.localRotation = closedPosRot.rot;
	}
}

[System.Serializable]
public class PosRot
{
	public Vector3 pos;
	public Quaternion rot;
}
