using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    [SerializeField] private FireBall _fireBallPrefab;
    [SerializeField] private Transform _spawnPoint;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(_fireBallPrefab, _spawnPoint.position, _spawnPoint.rotation);
        }
    }
}
