using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	// Salud del enemigo
	[SerializeField] float health = 100f;

	// Toma daño
	public void TakeDamage(float damage)
	{
		// Para evitar muerte por impacto simultáneo
		// Y la muerte después de muerto ya que no se destruye el objeto
		if (health > 0)
		{
			// Llama al método si está en algún script del objeto o sus hijos
			// SendMessage también valdría, solo que no mira los hijos
			BroadcastMessage("OnDamageTaken");
			// Queda menos vida
			health = health - damage;
			// Si está muerto
			if (health <= 0)
			{
				Die();
			}
		}
	}

	// Mata al enemigo
	private void Die()
	{
		// Activa la animación de morir
		gameObject.GetComponent<Animator>().SetTrigger("Die");
		// Desactiva la IA del enemigo para que no haga nada 
		gameObject.GetComponent<EnemyAI>().enabled = false;
	}
}
