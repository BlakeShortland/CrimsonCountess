/*
 * Script created by: Blake Shortland | Editor: [Null]
 */
using UnityEngine;
using Aura2API;

public class CeilingLightController : MonoBehaviour
{
	Light myLight;
	AuraLight auraLight;
	GameController gameController;

    bool isFlickering = false;

    float flickerTimer = 0f;
    float flickerDelay = .1f;
    float flickerFuse = 1f;


	void Start()
	{
		gameController = GameController.Instance;
		auraLight = GetComponent<AuraLight>();
		myLight = GetComponent<Light>();
		gameController.candleGrab.AddListener(DisableLight);
		gameController.candlePlace.AddListener(EnableLight);

    }

    public void StartFlicker()
    {
        isFlickering = true;

        flickerTimer = Random.Range(0f,1f);
    }

    public void StopFlicker()
    {
        isFlickering = false;
    }

    private void Update()
    {
        if (isFlickering)
        {
            flickerTimer += Time.deltaTime;
            if (flickerTimer >= flickerFuse)
            {
                float random = Random.Range(0, 100);
                if (random <= 5)
                {
                    Flicker();
                }
                flickerTimer = 0f;
            }
        }
    }

    public void Flicker()
    {
        DisableLight();
        Invoke("EnableLight", flickerDelay);
    }

    public void EnableLight()
	{
		auraLight.enabled = true;
		myLight.enabled = true;
	}

	public void DisableLight()
	{
		auraLight.enabled = false;
		myLight.enabled = false;
	}


}
