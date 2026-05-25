// PushableObstacle.cs
using UnityEngine;
using UnityEngine.AI;

public class PushableObstacle : MonoBehaviour {

    [Tooltip("Fuerza con la que el agente empujará el objeto.")]
    public float pushForce = 5.0f;
    
    private Rigidbody rb;

    void Start() {
        // Obtenemos el Rigidbody del propio obstáculo
        rb = GetComponent<Rigidbody>();
        
        if (rb == null) {
            Debug.LogError("Por favor, añade un componente Rigidbody al obstáculo: " + gameObject.name);
        }
    }

    // Se ejecuta continuamente mientras el agente esté tocando el obstáculo
    void OnCollisionStay(Collision collision) {
        // Comprobamos si lo que está tocando el obstáculo es un NavMeshAgent
        NavMeshAgent agent = collision.gameObject.GetComponent<NavMeshAgent>();

        if (agent != null) {
            // Calculamos la dirección del empuje usando la velocidad del agente
            Vector3 pushDirection = new Vector3(agent.velocity.x, 0, agent.velocity.z);

            // Si el agente se está moviendo, aplicamos la fuerza en su dirección
            if (pushDirection.magnitude > 0.1f) {
                rb.AddForce(pushDirection.normalized * pushForce, ForceMode.Force);
            }
        }
    }
}