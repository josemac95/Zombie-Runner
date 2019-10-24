using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
	// Función módulo (funciona bien con números negativos)
	Func<int, int, int> mod = (x, n) => (x % n + n) % n;

	// Arma actual
	int currentWeapon = 0;

	void Start()
	{
		SetActiveWeapon();
	}

	void Update()
	{
		int previousWeapon = currentWeapon;
		ProcessKeyInput();
		ProcessScrollWheel();
		if (previousWeapon != currentWeapon)
		{
			SetActiveWeapon();
		}
	}

	// Procesa las teclas
	private void ProcessKeyInput()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentWeapon = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			currentWeapon = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			currentWeapon = 2;
		}
	}

	// Procesa la rueda del ratón
	private void ProcessScrollWheel()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			currentWeapon = mod(currentWeapon + 1, transform.childCount);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			currentWeapon = mod(currentWeapon - 1, transform.childCount);
		}
	}

	// Activa el arma elegida
	private void SetActiveWeapon()
	{
		int weaponIndex = 0;
		// Recorre todos los hijos
		foreach (Transform weapon in transform)
		{
			if (weaponIndex == currentWeapon)
			{
				weapon.gameObject.SetActive(true);
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
			weaponIndex++;
		}
	}
}
