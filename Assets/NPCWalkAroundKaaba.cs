using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWalkAroundKaaba : MonoBehaviour
{
    [SerializeField] private int destCount = 64;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float angle;
    private NavMeshAgent agent;
    private Transform kaaba;
    List<Vector3> aroundDestsList = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        kaaba = GameObject.FindGameObjectWithTag("Kaaba").transform;
        InitDests();
        StartPatroling();
    }
    void InitDests()
    {
        angle = 1f / destCount;
        for (int i = 0; i < destCount; i++)
        {
            float x = kaaba.position.x + Mathf.Cos(angle * i * Mathf.PI * 2f) * radius;
            float z = kaaba.position.z + Mathf.Sin(angle * i * Mathf.PI * 2f) * radius;
            aroundDestsList.Add(new Vector3(x, transform.position.y, z));
        }       
    }
    void StartPatroling()
    {
        agent.SetDestination(aroundDestsList[currentPatrolIndex]);
    }
    void SetNextDest()
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % aroundDestsList.Count;
        agent.SetDestination(aroundDestsList[currentPatrolIndex]);
    }
    private int currentPatrolIndex = 0;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, agent.destination) < 0.1f)
        {
            SetNextDest();
        }
    }
}
