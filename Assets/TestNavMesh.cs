using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestNavMesh : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        foreach (Vector3 c in agent.path.corners)
            Debug.Log(c);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
