using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
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
		// No puede disparar
		gameObject.GetComponentInChildren<Weapon>().enabled = false;
		// No hay tiempo para que el juego no intervenga
		// En cambiar el modo del cursor
		Time.timeScale = 0;
		// Desbloquea el cursor para el menú
		Cursor.lockState = CursorLockMode.None;
		// Muestra el cursor
		Cursor.visible = true;
	}
}
