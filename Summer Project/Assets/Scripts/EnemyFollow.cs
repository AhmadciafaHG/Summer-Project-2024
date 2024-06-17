
using UnityEngine;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour
{
  private NavMeshAgent agent;
  public Transform target;
  public GameObject targetPrefab;
   void Awake()
  {
      agent = GetComponent<NavMeshAgent>();
  }
  // Update is called once per frame
  void Update()
  {
       if (target != null) // If this enemy has a target to follow...
       {
           agent.SetDestination(target.position); // Set that target's current position as this enemy's destination
       }
  }
  private void OnTriggerEnter(Collider collider)
   {
       if (collider.gameObject.CompareTag("Player")) // If the object this enemy just hit is the player...
       {
           // Despawn the player, and tell the GameManager to reset the current level
           targetPrefab.SetActive(false);
           GameManager.Instance.GameOver();
       }
   }
}
