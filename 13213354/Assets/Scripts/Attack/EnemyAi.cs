using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
