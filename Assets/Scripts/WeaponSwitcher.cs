using System; // Para definir la función en una linea
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
				SetActive(weapon.gameObject, true);
			}
			else
			{
				SetActive(weapon.gameObject, false);
			}
			weaponIndex++;
		}
	}

	// Desactiva las armas
	// Soluciona bug: cambiar de arma en la espera de la corrutina del disparo
	// Cuando vuelves canShoot sigue falso porque la corrutina se ha interrumpido
	// Si se pusiera canShoot a true en OnEnable al cambiar de arma se resetea el delay
	// Ocasionando otro bug, la solución es no desactivar el objeto, desactivar 
	// Los componentes hace que la corrutina no se interrumpa y todo va perfecto
	private void SetActive(GameObject weapon, bool value)
	{
		// No se ve
		MeshRenderer mesh = weapon.GetComponent<MeshRenderer>();
		if (mesh != null)
		{
			mesh.enabled = value;
		}
		MeshRenderer[] meshes = weapon.GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer childMesh in meshes)
		{
			childMesh.enabled = value;
		}
		// No puede disparar
		Weapon shoot = weapon.GetComponent<Weapon>();
		if (shoot != null)
		{
			shoot.enabled = value;
		}
		// No puede cambiar de arma
		WeaponSwitcher switcher = weapon.GetComponent<WeaponSwitcher>();
		if (switcher != null)
		{
			switcher.enabled = value;
		}
		// No puede hacer zoom con el arma
		WeaponZoom zoom = weapon.GetComponent<WeaponZoom>();
		if (zoom != null)
		{
			zoom.enabled = value;
		}
	}
}
