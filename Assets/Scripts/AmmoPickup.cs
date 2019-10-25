using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
	// Cantidad de munición que proporciona
	[SerializeField] int ammoAmount = 5;
	// Tipo de munición que proporciona
	[SerializeField] AmmoType ammoType = 0;

	// Manejo de la colisión
	private void OnTriggerEnter(Collider other)
	{
		// Tag player
		if (other.tag == "Player")
		{
			// Aumenta la cantidad de munición del jugador
			// Se podría poner FindObjectOfType<Ammo>()
			other.GetComponent<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmount);
			// Destruye el pickup
			Destroy(gameObject);
		}
	}
}
