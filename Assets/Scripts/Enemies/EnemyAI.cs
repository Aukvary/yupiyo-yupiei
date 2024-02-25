using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private List<Transform> TargetPoints;
    [SerializeField] private PlayerController _player;
    [SerializeField] private float ViewAngle;
    [SerializeField] private float _damege;

    private NavMeshAgent _agent;
    private PlayerHealth _playerHealth;
    private bool _playerIsTarget;
    
    void Start()
    {
        InitLinks();
        ChangeTarget();
    }

    private void InitLinks()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        TryToViewPlayer();
        ChoosePlayer();
        ChangeTarget();
        Attack();
    }
    
    private void ChangeTarget()
    {
        if (_agent.remainingDistance == 0 || !_playerIsTarget)
            _agent.destination = TargetPoints[Random.Range(0, TargetPoints.Count)].position;
    }

    private void ChoosePlayer()
    {
        if (_playerIsTarget)
            _agent.destination = _player.transform.position;
    }

    private void TryToViewPlayer()
    {
        var direction = _player.transform.position - transform.position;

        _playerIsTarget = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, direction, out hit, 5))
        {
            if (hit.collider.gameObject == _player.gameObject && Vector3.Angle(transform.forward, direction) < ViewAngle)
            {
                _playerIsTarget = true;
                
            }
        }
    }

    private void Attack()
    {
        if(_playerIsTarget)
        {
            if(_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _playerHealth.DealDamage(_damege * Time.deltaTime);
            }
        }
    }

    void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position + Vector3.up, _player.transform.position - transform.position);

        Gizmos.color = Color.yellow;

        Gizmos.DrawRay(ray);
    }

}
