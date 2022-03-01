using UnityEngine.AI;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Transform playerTransform;
    [SerializeField] Material normalMaterial;
    [SerializeField] Material scaredMaterial;

    bool wasDead;
    NavMeshAgent agent;
    Material material;
    Shader standardShader;
    Shader dissolveShader;
    new CapsuleCollider collider;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        standardShader = Shader.Find("Standard");
        dissolveShader = Shader.Find("Shader Graphs/Dissolve Shader Graph");

        material = GetComponent<Renderer>().material;
        material = normalMaterial;
        material.shader = standardShader;

        collider = GetComponent<CapsuleCollider>();
        collider.enabled = true;
    }

    void Update()
    {
        if (wasDead)
        {
            Invoke("NotDead", spawnDelay);
        }

        if (PlayerCollision.hasPower)
        {
            material = scaredMaterial;
        }
        else
        {
            material = normalMaterial;
            material.shader = standardShader;

            agent.SetDestination(playerTransform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerCollision.hasPower)
            {
                collider.enabled = false;
                PlayDissolveAnimation();
                collider.enabled = true;
                wasDead = true;
            }
            else
            {
                RespawnAll();
            }
        }
    }

    private void Respawn()
    {
        agent.enabled = false;
        transform.position = spawnPosition;
        agent.enabled = true;
    }

    private void PlayDissolveAnimation()
    {
        material.shader = dissolveShader;
        Invoke("Respawn", 1.5f);
        material = normalMaterial;
        material.shader = standardShader;
    }

    private void NotDead()
    {
        wasDead = false;
    }

    private void RespawnAll()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        foreach (GameObject ghost in ghosts)
        {
            ghost.GetComponent<GhostController>().Respawn();
        }
    }
}