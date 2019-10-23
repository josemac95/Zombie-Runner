using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	// Cantidad de munición
	[SerializeField] int ammoAmount = 10;

	// Cantidad actual
	public int GetCurrentAmmo()
	{
		return ammoAmount;
	}

	// Disminuye la cantidad
	public void ReduceCurrentAmmo()
	{
		ammoAmount--;
	}
}
