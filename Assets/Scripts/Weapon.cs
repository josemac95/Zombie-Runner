using System.Collections;
using UnityEngine;
using TMPro; // Para la UI (TextMeshPro)

public class Weapon : MonoBehaviour
{
	// Cámara de la primera persona
	[SerializeField] Camera FPCamera = null;
	// Rango del rayo
	[SerializeField] float range = 100f;
	// Daño del arma
	[SerializeField] float damage = 10f;
	// Efecto de disparo
	[SerializeField] ParticleSystem flashVFX = null;
	// Efecto del impacto
	[SerializeField] ParticleSystem hitVFX = null;
	// Efecto de sangre
	[SerializeField] ParticleSystem bloodVFX = null;
	// Arma automática
	[SerializeField] bool auto = true;
	// Lógica del disparo auto
	bool canShootAuto = true;
	// Lógica del disparo semi (delay)
	bool canShoot = true;
	// Balas por minuto
	[SerializeField] float fireRate = 600f;
	// Delay para el disparo semi
	[SerializeField] float delay = 0.25f;
	// Slot de munición
	[SerializeField] Ammo ammoSlot = null;
	[SerializeField] AmmoType ammoType;
	// Texto para el modo de disparo
	[SerializeField] TextMeshProUGUI fireModeText = null;
	// Silenciador
	[SerializeField] GameObject suppressor = null;

	// Se llama al comienzo (Start) y cada vez que se cambia de arma
	// Porque se desactiva el componente (también valdría el objeto) en el switcher
	void OnEnable()
	{
		SetLabelAuto();
	}

	void Update()
	{
		SwitchSuppressor();
		SwitchAuto();
		if (auto)
		{
			ShootAuto();
		}
		else
		{
			ShootSemi();
		}
	}

	// Pone el silenciador
	private void SwitchSuppressor()
	{
		// Si tiene silenciador
		if (suppressor != null)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				// Si está activo (no tiene en cuanta a su padre)
				if (suppressor.activeSelf)
				{
					suppressor.SetActive(false);
				}
				else
				{
					suppressor.SetActive(true);
				}
			}
		}
	}

	// Cambio modo auto - semi
	private void SwitchAuto()
	{
		if (Input.GetKeyDown(KeyCode.V))
		{
			auto = !auto;
			SetLabelAuto();
		}
	}

	// Pone la etiqueta correcta del modo de disparo
	private void SetLabelAuto()
	{
		if (auto)
		{
			fireModeText.text = "Auto";
		}
		else
		{
			fireModeText.text = "Semi";
		}
	}

	// Dispara arma automática
	private void ShootAuto()
	{
		if (Input.GetButton("Fire1") && canShootAuto)
		{
			StartCoroutine(AutoShooting());
		}
	}

	// Corutina disparo automático
	private IEnumerator AutoShooting()
	{
		canShootAuto = false;
		Shoot();
		float delay = 1 / (fireRate / 60f);
		yield return new WaitForSeconds(delay);
		canShootAuto = true;
	}

	// Dispara arma semi-automática
	private void ShootSemi()
	{
		if (Input.GetButtonDown("Fire1") && canShoot)
		{
			StartCoroutine(SemiShooting());
		}
	}

	// Corutina disparo semi-automático
	private IEnumerator SemiShooting()
	{
		canShoot = false;
		Shoot();
		yield return new WaitForSeconds(delay);
		canShoot = true;
	}


	// Dispara
	private void Shoot()
	{
		// Si hay balas
		if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
		{
			ammoSlot.ReduceCurrentAmmo(ammoType);
			PlayFlashVFX();
			ProcessRaycast();
		}
	}

	// Efecto de disparo del arma
	private void PlayFlashVFX()
	{
		// Si no hay silenciador (no hay opción)
		if (suppressor == null)
		{
			flashVFX.Play();
		}
		// Si el silenciador está puesto, no hay flash
		else if (!suppressor.activeSelf)
		{
			flashVFX.Play();
		}
	}

	// Procesamiento del raycast
	private void ProcessRaycast()
	{
		// Variable con la información del impacto
		RaycastHit hit;
		// Castea el rayo
		bool impacted = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
		// Si hay impacto
		if (impacted)
		{
			// Daña al enemigo
			EnemyHealth target = hit.collider.GetComponent<EnemyHealth>();
			if (target != null)
			{
				target.TakeDamage(damage);
				// Efecto de impacto (sangre)
				PlayHitVFX(bloodVFX, hit);
			}
			else
			{
				// Efecto de impacto
				PlayHitVFX(hitVFX, hit);
			}
		}
	}

	// Efecto del impacto
	private void PlayHitVFX(ParticleSystem hitVFX, RaycastHit hit)
	{
		// El efecto se crea en la posición del impacto y perpendicular
		ParticleSystem impact = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
		// No me hace falta destruir el efecto
		// Porque he puesto Stop Action = Destroy
	}
}
