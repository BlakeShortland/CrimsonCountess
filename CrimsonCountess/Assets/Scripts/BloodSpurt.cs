using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSpurt : MonoBehaviour
{
	GameController gameController;

	public ParticleSystem part;
	public List<ParticleCollisionEvent> collisionEvents;

	

	void Start()
    {
		gameController = GameController.Instance;

		part = GetComponent<ParticleSystem>();
	}

	private void OnParticleCollision(GameObject other)
	{
		if (other.name == "Stone Slab" && gameController.bookPlaced && gameController.candlePlaced)
		{
			gameController.RitualCompleted();
		}
	}

	void Update()
	{
		if (part.isStopped)
		{
			Destroy(gameObject);
		}
	}
}
