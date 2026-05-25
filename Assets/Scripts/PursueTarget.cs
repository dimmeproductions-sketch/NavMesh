using UnityEngine;
using UnityEngine.AI;

public class PursueTarget : MonoBehaviour {

    [Tooltip("Asigna aquí al Agente 1 (el cilindro) que quieres perseguir.")]
    public Transform target; 
    
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        // Nos aseguramos de que haya un objetivo asignado para evitar errores
        if (target != null) {
            agent.SetDestination(target.position);
        }
    }
}