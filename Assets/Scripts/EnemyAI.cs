using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

	// Jugador
	[SerializeField] Transform target = null;
	// AI del enemigo
	NavMeshAgent navMeshAgent;
	// Rango de detección
	[SerializeField] float chaseRange = 10f;
	// Distancia al objetivo (por defecto infinito)
	float distanceToTarget = Mathf.Infinity;
	// Si está provocado
	bool isProvoked = false;


	void Start()
	{
		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
	}

	void Update()
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

	// Asalta al objetivo
	private void EngageTarget()
	{
		// Persigue al enemigo si no llega a la distancia de parada
		if (distanceToTarget >= navMeshAgent.stoppingDistance)
		{
			ChaseTarget();
		}
		// Si está cerca, ataca
		else
		{
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
		// Va hacia el jugador
		navMeshAgent.SetDestination(target.position);
	}

	// Ataca al objetivo
	private void AttackTarget()
	{
		// Activa la animación de atacar
		gameObject.GetComponent<Animator>().SetBool("Attack", true);
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
