using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	// Canvas del menú de game over
	[SerializeField] Canvas gameOverCanvas = null;

	void Start()
	{
		// No se ve la pantalla del game over
		gameOverCanvas.enabled = false;
	}

	// Manejo de la muerte del jugador
	public void HandleDeath()
	{
		// Vuelve a activar el menú de game over
		gameOverCanvas.enabled = true;
		// Desactiva scripts de armas
		DisableWeaponScripts();
		// No hay tiempo para que el juego no intervenga
		// En cambiar el modo del cursor
		Time.timeScale = 0;
		// Desbloquea el cursor para el menú
		Cursor.lockState = CursorLockMode.None;
		// Muestra el cursor
		Cursor.visible = true;
	}

	// Desactiva el disparo, el switcher y el zoom
	private void DisableWeaponScripts()
	{
		// No puede disparar
		Weapon weapon = gameObject.GetComponentInChildren<Weapon>();
		if (weapon != null)
		{
			weapon.enabled = false;
		}
		// No puede cambiar de arma
		WeaponSwitcher switcher = gameObject.GetComponentInChildren<WeaponSwitcher>();
		if (switcher != null)
		{
			switcher.enabled = false;
		}
		// No puede hacer zoom con el arma
		WeaponZoom zoom = gameObject.GetComponentInChildren<WeaponZoom>();
		if (zoom != null)
		{
			zoom.enabled = false;
		}
	}
}
