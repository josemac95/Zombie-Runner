using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	// Cámara de la primera persona
	[SerializeField] Camera FPCamera = null;
	// Rango del rayo
	[SerializeField] float range = 100f;
	// Daño del arma
	[SerializeField] float damage = 10f;
	// Efecto de disparo
	[SerializeField] ParticleSystem flashVFX = null;
	// Efecto del impacto
	[SerializeField] ParticleSystem hitVFX = null;
	// Efecto de sangre
	[SerializeField] ParticleSystem bloodVFX = null;
	// Arma automática
	[SerializeField] bool auto = false;

	void Update()
	{
		if (auto)
		{
			ShootAuto();
		}
		else
		{
			ShootSemi();
		}
	}

	// Dispara arma automática
	private void ShootAuto()
	{
		if (Input.GetButton("Fire1"))
		{
			Shoot();
		}
	}

	// Dispara arma semi-automática
	private void ShootSemi()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	// Dispara
	private void Shoot()
	{
		PlayFlashVFX();
		ProcessRaycast();
	}

	// Efecto de disparo del arma
	private void PlayFlashVFX()
	{
		flashVFX.Play();
	}

	// Procesamiento del raycast
	private void ProcessRaycast()
	{
		// Variable con la información del impacto
		RaycastHit hit;
		// Castea el rayo
		bool impacted = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
		// Si hay impacto
		if (impacted)
		{
			// Daña al enemigo
			EnemyHealth target = hit.collider.GetComponent<EnemyHealth>();
			if (target != null)
			{
				target.TakeDamage(damage);
				// Efecto de impacto (sangre)
				PlayHitVFX(bloodVFX, hit);
			}
			else
			{
				// Efecto de impacto
				PlayHitVFX(hitVFX, hit);
			}
		}
	}

	// Efecto del impacto
	private void PlayHitVFX(ParticleSystem hitVFX, RaycastHit hit)
	{
		// El efecto se crea en la posición del impacto y perpendicular
		ParticleSystem impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
		// No me hace falta destruir el efecto
		// Porque he puesto Stop Action = Destroy
	}
}
