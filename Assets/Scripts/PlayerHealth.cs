using UnityEngine;
using TMPro; // Para la UI (TextMeshPro)

public class PlayerHealth : MonoBehaviour
{
	// Salud del jugador
	[SerializeField] float health = 100f;
	// Texto para la vida
	[SerializeField] TextMeshProUGUI healthText = null;

	void Update()
	{
		DisplayHealh();
	}

	// Muestra la UI de la vida
	private void DisplayHealh()
	{
		healthText.text = health.ToString();
	}

	// Toma daño
	public void TakeDamage(float damage)
	{
		// Para evitar muerte por impacto simultáneo
		if (health > 0)
		{
			// Queda menos vida
			health = health - damage;
			// Si está muerto
			if (health <= 0)
			{
				Die();
			}
		}
	}

	// Mata al jugador
	private void Die()
	{
		DeathHandler handler = gameObject.GetComponent<DeathHandler>();
		handler.HandleDeath();
	}
}