using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	// Objetivo al que ataca
	PlayerHealth target = null;
	// Daño por impacto
	[SerializeField] float damage = 40f;

	void Start()
	{
		target = FindObjectOfType<PlayerHealth>();
	}

	// Se llama en la animación de ataque
	public void AttackHitEvent()
	{
		if (target != null)
		{
			print("PUM! " + damage + " damage");
			// Quita vida
			target.TakeDamage(damage);
		}
	}
}
