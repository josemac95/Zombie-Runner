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

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	// Dispara
	private void Shoot()
	{
		// Variable con la información del impacto
		RaycastHit hit;
		// Castea el rayo
		bool impacted = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
		// Si hay impacto
		if (impacted)
		{
			print(hit.collider.name);
		}
	}
}
