using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

	// Jugador
	Transform target = null;
	// AI del enemigo
	NavMeshAgent navMeshAgent;
	// Rango de detección
	[SerializeField] float chaseRange = 10f;
	// Distancia al objetivo (por defecto infinito)
	float distanceToTarget = Mathf.Infinity;
	// Si está provocado
	bool isProvoked = false;
	// Velocidad de rotación
	[SerializeField] float turnSpeed = 10f;

	void Start()
	{
		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
		// Jugador
		PlayerHealth player = FindObjectOfType<PlayerHealth>();
		if (player != null)
		{
			target = player.transform;
		}
		else
		{
			Debug.LogWarning("No player (PlayerHealth Script)");
		}
	}

	void Update()
	{
		if (target != null)
		{
			// Actualiza la distancia
			distanceToTarget = Vector3.Distance(target.position, transform.position);
			// Si está provocado
			if (isProvoked)
			{
				EngageTarget();
			}
			// Si está en el rango
			else if (distanceToTarget < chaseRange)
			{
				// Está provocado
				isProvoked = true;
			}
		}
	}

	// Asalta al objetivo
	private void EngageTarget()
	{
		// Persigue al objetivo si no llega a la distancia de parada
		if (distanceToTarget >= navMeshAgent.stoppingDistance)
		{
			ChaseTarget();
		}
		// Si está cerca, ataca
		else
		{
			FaceTarget();
			AttackTarget();
		}

	}

	// Persigue al objetivo
	private void ChaseTarget()
	{
		// Desactiva la animación de atacar
		gameObject.GetComponent<Animator>().SetBool("Attack", false);
		// Activa la animación de mover
		gameObject.GetComponent<Animator>().SetTrigger("Move");
		// Va hacia el 
		navMeshAgent.SetDestination(target.position);
	}

	// Ataca al objetivo
	private void AttackTarget()
	{
		// Activa la animación de atacar
		gameObject.GetComponent<Animator>().SetBool("Attack", true);
	}

	// Encara al objetivo
	private void FaceTarget()
	{
		// Dirección
		// Normalizada porque no importa la magnitud, aunque es irrelevante
		Vector3 direction = (target.position - transform.position).normalized;
		// Quitamos el eje y para que solo mire hacia los lados
		direction = new Vector3(direction.x, 0, direction.z);
		// Rotación deseada
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		// Rotación suave para que no sea al instante
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
		// ALTERNATIVAMENTE SE PODRÍA UTILIZAR TRANSFORM.LOOKAT
		// Pero sería una rotación instantánea igual que si se hace
		// transform.rotation = lookRotation;
	}

	// Dibuja cosas para debug
	// OnDrawGizmosSelected dibuja solo si se selecciona
	void OnDrawGizmos()
	{
		// Rango de detección (esfera con alfa al 50%)
		Color gizmosColor = Color.red;
		gizmosColor.a = 0.5f;
		Gizmos.color = gizmosColor;
		Gizmos.DrawSphere(transform.position, chaseRange);
	}
}
