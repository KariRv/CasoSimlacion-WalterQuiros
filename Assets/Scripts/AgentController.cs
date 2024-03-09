using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

 // Ataque del Agente vale 25 PUNTOS
public class AgentController : AttackController
{
    [SerializeField]
    Transform target;

    //[SerializeField]
    //Transform attackPoint;
    // Distancia minima

    [SerializeField]
    float damage = 25.0f;

    Animator _animator;

    [SerializeField]
    float minDistance = 5.0f;

    [SerializeField]
    float attackCooldown;

    float attackTime;

    NavMeshAgent _navAgent;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        // Si la distancia es menor o igual a la distancia minima entonces ataque

        if (distance <= minDistance && Time.time - attackTime >= attackCooldown)
        {
            HealthController playerHealth = target.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                attackTime = Time.time;
            }
           
        }
        _navAgent.SetDestination(target.position);
    }

    public override void Attack()
    {
        _animator.SetTrigger("attack");
    }

    //pruebas de animar el wand del enemigo **Ignorar** :P
    //private void AgentAttack()
    //{
    //    Collider[] others = Physics.OverlapSphere(attackPoint.position, 0.3F);
    //    foreach (Collider other in others)
    //    {
    //        HealthController controller = other.GetComponent<HealthController>();
    //        if (controller != null)
    //        {
    //            controller.TakeDamage(damage);
    //        }
    //    }
    // }
}
