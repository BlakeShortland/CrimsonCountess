using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnLoad : MonoBehaviour
{
	[SerializeField] Vector3 startPos;

    void Start()
    {
		transform.localPosition = startPos;
    }
}
