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
		transform.localRotation = Quaternion.Euler(0, openPosRot.rot, 0);
	}

	public void CloseDoor()
	{
		transform.localPosition = closedPosRot.pos;
		transform.localRotation = Quaternion.Euler(0, closedPosRot.rot, 0);
	}
}

[System.Serializable]
public class PosRot
{
	public Vector3 pos;
	public float rot;
}
