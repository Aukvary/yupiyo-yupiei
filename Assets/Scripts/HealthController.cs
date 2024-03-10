using UnityEngine;

public abstract class HealthController : MonoBehaviour 
{
    [SerializeField] private float _health;
    protected float health 
    {
        get => _health;
        set 
        {
            _health = value;
            if (_health <= 0)
                Die();
        }
    }

    public virtual void DealDamage(float damage)
    {
        health -= damage;
    }

    protected virtual void OnTriggerEnter(Collider col)
    {
        var explosion = col.GetComponent<Explosion>();
        if (explosion != null)
        {
            DealDamage(explosion.damage);
        }
    }

    protected abstract void Die();
}