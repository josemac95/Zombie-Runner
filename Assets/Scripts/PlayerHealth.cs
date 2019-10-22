using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float health = 100f;

	// Toma daño
	public void TakeDamage(float damage)
	{
		// Para evitar muerte por impacto simultáneo
		if (health > 0)
		{
			// Queda menos vida
			health = health - damage;
			// Si está muerto
			if (health <= 0)
			{
				Die();
			}
		}
	}

	// Mata al jugador
	private void Die()
	{
		print("muerto");
	}
}