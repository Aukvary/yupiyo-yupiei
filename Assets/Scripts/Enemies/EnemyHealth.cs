using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    private void OnCollisionEnter(Collision collision)
    {
        var fireball = collision.gameObject.GetComponent<FireBall>();
        if (fireball)
        {
            _health -= fireball.damage;
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}
