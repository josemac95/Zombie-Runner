using System.Collections;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
	// Canvas con la UI para el daño
	[SerializeField] Canvas impactCanvas = null;
	// Duración del impacto
	[SerializeField] float impactTime = 0.3f;

	void Start()
	{
		impactCanvas.enabled = false;
	}

	// Muestra la sangre
	public void DisplayBlood()
	{
		StartCoroutine(ShowSplatter());
	}

	// Corrutina para mostrar la salplicadura y luego quitarla
	private IEnumerator ShowSplatter()
	{
		impactCanvas.enabled = true;
		yield return new WaitForSeconds(impactTime);
		impactCanvas.enabled = false;
	}
}
