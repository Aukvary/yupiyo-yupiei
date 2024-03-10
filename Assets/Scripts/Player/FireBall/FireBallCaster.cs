using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    [SerializeField] private FireBall _fireBallPrefab;
    [SerializeField] private Transform _spawnPoint;
    public float damage;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var fireball = Instantiate(_fireBallPrefab, _spawnPoint.position, _spawnPoint.rotation);
            fireball.damage = damage;
        }
    }
}
