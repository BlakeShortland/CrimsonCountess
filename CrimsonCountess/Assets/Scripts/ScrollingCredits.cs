using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingCredits : MonoBehaviour
{
	public RectTransform myTransform;

	public float scrollSpeed = 10f;

	[SerializeField] Vector3 startPos;
	[SerializeField] Vector3 endPos;

	float startTime;
	float journeyLength;

	void Start()
	{
		journeyLength = Vector3.Distance(startPos, endPos);

		Restart();
	}

	void Restart()
	{
		myTransform.localPosition = startPos;
		startTime = Time.time;
	}

	void Update()
	{
		float distCovered = (Time.time - startTime) * scrollSpeed;

		float fractionOfJourney = distCovered / journeyLength;

		myTransform.localPosition = Vector3.Lerp(startPos, endPos, fractionOfJourney);

		if (myTransform.localPosition.y >= endPos.y)
			Restart();
	}
}
