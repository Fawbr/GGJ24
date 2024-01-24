using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] travelPoints;
    NavMeshAgent nMA;
    [SerializeField] GameObject waypoint;
    [SerializeField] Transform travelNode;
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        waypoint = GameObject.Find("Waypoints");
        travelPoints = waypoint.GetComponentsInChildren<Transform>();
        NewNode();
        nMA.speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, travelNode.position) <= 1f)
        {
            NewNode();
        }
    }

    void NewNode()
    {
        if (travelNode == null)
        {
            travelNode = travelPoints[Random.Range(0, travelPoints.Length)];
            if (travelNode.name == "Waypoints")
            {
                NewNode();
            }
        }
        else
        {
            Transform previousNode = travelNode;
            travelNode = travelPoints[Random.Range(0, travelPoints.Length)];
            if (travelNode.name == previousNode.name || travelNode.name == "Waypoints")
            {
                NewNode();
            }
        }
        nMA.SetDestination(travelNode.position);
    }
}
