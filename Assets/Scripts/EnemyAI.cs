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

	void Start()
	{
		navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		// Va hacia el jugador
		navMeshAgent.SetDestination(target.position);
	}
}
