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


	void Start()
	{
		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		// Actualiza la distancia y comprueba si está en el rango
		distanceToTarget = Vector3.Distance(target.position, transform.position);
		if (distanceToTarget < chaseRange)
		{
			// Va hacia el jugador
			navMeshAgent.SetDestination(target.position);
		}
	}
}
