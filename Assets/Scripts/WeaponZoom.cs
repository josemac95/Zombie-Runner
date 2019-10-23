﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson; // Para el FPS Controller

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
	// Para la sensibilidad
	RigidbodyFirstPersonController controller;
	// Sensibilidad por defecto
	[SerializeField] float zoomOutSensitivity = 2f;
	// Sensibilidad con zoom activado
	[SerializeField] float zoomInSensitivity = 0.5f;

	void Start()
	{
		controller = gameObject.GetComponent<RigidbodyFirstPersonController>();
	}

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
				ZoomIn();
			}
			else
			{
				zoomInToggle = false;
				ZoomOut();
			}
		}
	}

	// Hace zoom si pulsa botón derecho
	private void Zoom()
	{
		if (Input.GetButtonDown("Fire2"))
		{
			ZoomIn();
		}
		else if (Input.GetButtonUp("Fire2"))
		{
			ZoomOut();
		}
	}

	// Si se hace zoom cambia el FOV y la sensibilidad
	private void ZoomIn()
	{
		FPCamera.fieldOfView = zoomInFOV;
		controller.mouseLook.XSensitivity = zoomInSensitivity;
		controller.mouseLook.YSensitivity = zoomInSensitivity;
	}

	// Si se hace zoom cambia el FOV y la sensibilidad
	private void ZoomOut()
	{
		FPCamera.fieldOfView = zoomOutFOV;
		controller.mouseLook.XSensitivity = zoomOutSensitivity;
		controller.mouseLook.YSensitivity = zoomOutSensitivity;
	}
}
