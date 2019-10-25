using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
	// Manejo de la colisión
	private void OnTriggerEnter(Collider other)
	{
		// Tag player
		if (other.tag == "Player")
		{
			print("PICKUP");
		}
	}
}
