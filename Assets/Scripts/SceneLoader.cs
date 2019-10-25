using UnityEngine;
using UnityEngine.SceneManagement; // Manejo de escenas

public class SceneLoader : MonoBehaviour
{
	// Carga el juego
	public void ReloadGame()
	{
		SceneManager.LoadScene(0);
		// Reestablece el paso del tiempo tras morir
		Time.timeScale = 1;
	}

	// Cierra el juego
	public void QuitGame()
	{
		Application.Quit();
	}
}
