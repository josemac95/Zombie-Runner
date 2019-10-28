using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
	// Cantidad de intensidad que restaura
	[SerializeField] int intensityAmount = 1;
	// Cantidad de ángulo que restaura
	[SerializeField] int angleAmount = 70;

	// Manejo de la colisión
	private void OnTriggerEnter(Collider other)
	{
		// Tag player
		if (other.tag == "Player")
		{
			// Restaura la luz
			// Se podría poner FindObjectOfType<FlashLightSystem>()
			other.GetComponentInChildren<FlashLightSystem>().RestoreLight(intensityAmount, angleAmount);
			// Destruye el pickup
			Destroy(gameObject);
		}
	}
}
