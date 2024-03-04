using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;

    private void OnCollisionEnter(Collision col)
    {
        var fireball = col.gameObject.GetComponent<FireBall>();
        if (fireball != null)
            DealDamage(fireball.damage);
    }

    private void OnTriggerEnter(Collider col)
    {
        var explosion = col.gameObject.GetComponent<Explosion>();

        if (explosion != null)
        {
            DealDamage(explosion.damage);
        }

    }

    private void DealDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
