using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
	// Cámara de la primera persona
	[SerializeField] Camera FPCamera = null;
	// Zoom por defecto
	[SerializeField] float zoomOutFOV = 60f;
	// Zoom activado
	[SerializeField] float zoomInFOV = 30f;
	// Zoom toggle
	bool zoomInToggle = false;
	// Activar modo toggle
	[SerializeField] bool toggle = true;

	void Update()
	{
		SwitchToggle();
		if (toggle)
		{
			ZoomToggle();
		}
		else
		{
			Zoom();
		}
	}

	// Cambio modo toggle
	private void SwitchToggle()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			toggle = !toggle;
		}
	}

	// Hace zoom si pulsa botón derecho (función toggle)
	private void ZoomToggle()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			if (!zoomInToggle)
			{
				zoomInToggle = true;
				FPCamera.fieldOfView = zoomInFOV;
			}
			else
			{
				zoomInToggle = false;
				FPCamera.fieldOfView = zoomOutFOV;
			}
		}
	}

	// Hace zoom si pulsa botón derecho
	private void Zoom()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			FPCamera.fieldOfView = zoomInFOV;
		}
		else if (Input.GetButtonUp("Fire2"))
		{
			FPCamera.fieldOfView = zoomOutFOV;
		}
	}
}
