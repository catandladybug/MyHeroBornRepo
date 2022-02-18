using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlagEnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    private int _lives = 3;

    private Rigidbody _rb;
    private CapsuleCollider _col;

    public int EnemyLives
    {

        get { return _lives; }

        private set
        {

            _lives = value;

            if (_lives <= 0)
            {

                Destroy(this.gameObject);
                Debug.Log("Enemy down.");

            }
        }
    }

    private void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();

        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();

    }

    private void Update()
    {

        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {

            MoveToNextPatrolLocation();

        }
    }

    void MoveToNextPatrolLocation()
    {

        if (locations.Count == 0)
            return;

        agent.destination = locations[locationIndex].position;

        locationIndex = (locationIndex + 1) % locations.Count;

    }

    private void InitializePatrolRoute()
    {

        foreach (Transform child in patrolRoute)
        {

            locations.Add(child);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Bullet(Clone)")
        {

            EnemyLives -= 1;
            Debug.Log("Critical hit!");

        }
    }

    public GameObject myHat;
    public void ShowHat()
    {
        myHat.SetActive(true);
    }
}