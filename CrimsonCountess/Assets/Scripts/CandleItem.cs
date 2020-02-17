public class CandleItem : Candle
{
	public override void Start()
	{
		base.Start();

		myFlameEmitter.Stop();
		myLight.SetActive(false);
	}

	public override void Extinguish()
	{
		myFlameEmitter.Play();
		myLight.SetActive(true);
		mySmokeEmitter.Stop();
	}
}
