using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    void Start () {
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update () {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius) {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance) {
                //Death

                FaceTarget();
            }
        }
    }

    void FaceTarget () {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}