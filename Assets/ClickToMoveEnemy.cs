using UnityEngine;
using UnityEngine.AI;

public class ClickToMoveEnemy : MonoBehaviour
{
    public Transform Target;
    public float detectionRadius = 10f; // Define o tamanho da região/raio de detecção
    private NavMeshAgent m_Agent;

    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula a distância atual entre o NPC e o Target (Player)
        float distanceToTarget = Vector3.Distance(transform.position, Target.position);

        // Se o Target estiver dentro do raio de detecção, o NPC o persegue
        if (distanceToTarget <= detectionRadius)
        {
            m_Agent.isStopped = false; 
            m_Agent.destination = Target.position;
        }
        else
        {
  
            if (m_Agent.hasPath)
            {
                m_Agent.isStopped = true; 
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}