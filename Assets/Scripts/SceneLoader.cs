using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Manejo de escenas

public class SceneLoader : MonoBehaviour
{
	// Carga el juego
	public void ReloadGame()
	{
		SceneManager.LoadScene(0);
	}

	// Cierra el juego
	public void QuitGame()
	{
		Application.Quit();
	}
}
