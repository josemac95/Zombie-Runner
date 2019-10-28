using UnityEngine;
using UnityEngine.AI; // Para acceder a NavMeshAgent

public class EnemyHealth : MonoBehaviour
{
	// Salud del enemigo
	[SerializeField] float health = 100f;
	// Si está muerto
	bool dead = false;
	// Posición de muerte
	Vector3 deadPos;

	void Update()
	{
		// Bloquea la posición para que no se deslice por el mapa
		if (dead)
		{
			// Posición de muerte
			transform.position = deadPos;
		}
	}

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
		// Quita el NavMeshAgent para no bloquear el paso a los otros enemigos
		gameObject.GetComponent<NavMeshAgent>().enabled = false;
		// Quita el collider para no molestar el paso
		gameObject.GetComponent<Collider>().enabled = false;
		// Está muerto
		dead = true;
		deadPos = transform.position;
	}
}
