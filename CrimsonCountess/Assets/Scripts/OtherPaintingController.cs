using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPaintingController : MonoBehaviour
{
	GameController gameController;

	Renderer paintingRenderer;
	public Texture[] paintingStages = new Texture[3];

	void Start()
    {
		gameController = GameController.Instance;

		paintingRenderer = GetComponent<Renderer>();

		paintingRenderer.material.mainTexture = paintingStages[0];

		gameController.candleGrab.AddListener(SecondStage);
		gameController.bookPickedUp.AddListener(ThirdStage);
	}

    void SecondStage()
	{
		paintingRenderer.material.mainTexture = paintingStages[1];
	}

	void ThirdStage()
	{
		paintingRenderer.material.mainTexture = paintingStages[2];
	}
}
