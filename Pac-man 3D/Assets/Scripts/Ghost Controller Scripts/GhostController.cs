using UnityEngine.AI;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Transform targetTransform;
    [SerializeField] Material normalMaterial;
    [SerializeField] Material scaredMaterial;

    bool wasDead;
    NavMeshAgent agent;
    new CapsuleCollider collider;

    Material material;
    Shader standardShader;
    Shader dissolveShader;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        Invoke(nameof(EnableMovement), spawnDelay);
        standardShader = Shader.Find("Standard");
        dissolveShader = Shader.Find("Shader Graphs/Dissolve Shader Graph");

        material = GetComponent<Material>();

        collider = GetComponent<CapsuleCollider>();
        collider.enabled = true;
    }

    void Update()
    {
        if (!PlayerCollision.winGame && !PlayerCollision.loseGame)
        {
            if (wasDead)
            {
                Invoke(nameof(NotDead), spawnDelay);
            }

            if (PlayerCollision.hasPower)
            {
                agent.SetDestination(spawnPosition);
            }
            else
            {
                if (agent.enabled)
                {
                    agent.SetDestination(targetTransform.position);
                }
            }
        }
        else
        {
            agent.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerCollision.hasPower)
            {
                collider.isTrigger = false;
                material.shader = dissolveShader;
                PlayDissolveAnimation();
            }
            else
            {
                Respawn();
            }
        }
    }

    private void Respawn()
    {
        agent.enabled = false;
        transform.position = spawnPosition;
        Invoke(nameof(EnableMovement), spawnDelay);
    }

    private void PlayDissolveAnimation()
    {
        Invoke(nameof(Respawn), 1.5f);
        material = normalMaterial;
        material.shader = standardShader;
        collider.isTrigger = true;
        wasDead = true;
    }

    private void NotDead()
    {
        wasDead = false;
    }

    private void EnableMovement()
    {
        agent.enabled = true;
    }
}