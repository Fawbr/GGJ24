using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] travelPoints;
    [SerializeField] GameObject player;
    [SerializeField] EnemyBrain enemyBrain;
    NavMeshAgent nMA;
    Animator batAnim;
    [SerializeField] GameObject waypoint;
    [SerializeField] Transform travelNode;
    Rigidbody rb;
    float time;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject bloodPrefab;
    [SerializeField] public bool isAggressive;
    private void OnEnable()
    {
        nMA = GetComponent<NavMeshAgent>();
        enemyBrain = GetComponentInParent<EnemyBrain>();
        nMA.enabled = true;
        isAggressive = false;
        rb = GetComponent<Rigidbody>();
        batAnim = bat.GetComponent<Animator>();
        waypoint = GameObject.Find("Waypoints");
        travelPoints = waypoint.GetComponentsInChildren<Transform>();
        NewNode();
        player = GameObject.Find("Player");
        nMA.speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAggressive)
        {
            bat.SetActive(false);
            if (Vector3.Distance(transform.position, travelNode.position) <= 1f)
            {
                NewNode();
            }
        }
        else
        {
            bat.SetActive(true);
            nMA.SetDestination(player.transform.position);
            //transform.LookAt(player.transform.position);
            EnemySwing();
        }
    }

    public void NewNode()
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

    void EnemySwing()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 3f)
        {
            nMA.ResetPath();
            batAnim.Play("Swing");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bat")
        {
            enemyBrain.RemoveFromBrain();
            rb.isKinematic = false;
            nMA.enabled = false;
            this.enabled = false;
            rb.AddForce(player.transform.forward * 1000f, ForceMode.Force);
            Instantiate(bloodPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        }
    }

    
}
