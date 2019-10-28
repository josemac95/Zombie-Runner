using System.Collections;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
	// La intensidad de la luz decrece con el uso
	[SerializeField] float intensityDecay = 0.1f;
	// Intensidad máxima
	[SerializeField] float maxIntensity = 2f;
	// Intensidad mínima
	[SerializeField] float minIntensity = 0f;
	// El ángulo decrece con el uso
	[SerializeField] float angleDecay = 1.5f;
	// Ángulo mínimo
	[SerializeField] float minAngle = 40f;
	// Ángulo máximo
	[SerializeField] float maxAngle = 70f;
	// La luz
	Light myLight;

	void Start()
	{
		myLight = gameObject.GetComponent<Light>();
		myLight.intensity = maxIntensity;
		myLight.spotAngle = maxAngle;
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

	// Reestablece la luz
	public void RestoreLight(float intensityAmount, float angleAmount)
	{
		myLight.intensity = Mathf.Min(maxIntensity, myLight.intensity + intensityAmount);
		myLight.spotAngle = Mathf.Min(maxAngle, myLight.spotAngle + angleAmount);
	}
}
