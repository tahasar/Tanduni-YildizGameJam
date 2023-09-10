using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{

    public Transform[] points;

    private int _current;

    [SerializeField] private float speed = 2;
    public NavMeshAgent agent;
    public int targetNumber;
    private float _targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        _current = 0;
        targetNumber = Random.Range(0, points.Length);
    }

    // Update is called once per frame
    void Update()
    {
        _targetDistance = Vector2.Distance(points[targetNumber].position, transform.position);
        
        if (_targetDistance > 0.5f)
        {
            agent.SetDestination(points[targetNumber].position);
        }
        else
        {
            targetNumber = Random.Range(0,points.Length);
        }
    }
}
