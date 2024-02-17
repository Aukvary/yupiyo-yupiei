using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private List<Transform> TargetPoints;
    [SerializeField] private PlayerController Player;
    [SerializeField] private float ViewAngle;

    private NavMeshAgent _agent;
    private bool _playeristarget;
    
    void Start()
    {
        InitLinks();
        ChangeTarget();
    }

    private void InitLinks()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        TryToViewPlayer();
        ChoosePlayer();
        ChangeTarget();
    }
    
    private void ChangeTarget()
    {
        if (_agent.remainingDistance == 0 && !_playeristarget)
            _agent.destination = TargetPoints[Random.Range(0, TargetPoints.Count)].position;
    }

    private void ChoosePlayer()
    {
        if (_playeristarget)
            _agent.destination = Player.transform.position;
    }

    private void TryToViewPlayer()
    {
        var direction = Player.transform.position - transform.position;

        _playeristarget = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
        {
            if (hit.collider.gameObject == Player.gameObject && Vector3.Angle(transform.forward, direction) < ViewAngle)
            {
                _playeristarget = true;
                
            }
        }
        
        Debug.Log(_playeristarget);
    }

    void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Player.transform.position - transform.position);

        Gizmos.color = Color.yellow;

        Gizmos.DrawRay(ray);
    }

}
