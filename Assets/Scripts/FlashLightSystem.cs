using System.Collections;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
	// La intensidad de la luz decrece con el uso
	[SerializeField] float intensityDecay = 0.1f;
	// Intensidad mínima
	[SerializeField] float minIntensity = 0f;
	// El ángulo decrece con el uso
	[SerializeField] float angleDecay = 1.5f;
	// Ángulo mínimo
	[SerializeField] float minAngle = 40f;
	// La luz
	Light myLight;

	void Start()
	{
		myLight = gameObject.GetComponent<Light>();
	}

	void Update()
	{
		DecreaseLightIntensity();
		DecreaseLightAngle();
	}

	// Reduce la intensidad de la luz
	private void DecreaseLightIntensity()
	{
		if (myLight.intensity > minIntensity)
		{
			myLight.intensity -= intensityDecay * Time.deltaTime;
		}
	}

	// Reduce el ángulo de la luz
	private void DecreaseLightAngle()
	{
		if (myLight.spotAngle > minAngle)
		{
			myLight.spotAngle -= angleDecay * Time.deltaTime;
		}
	}
}
