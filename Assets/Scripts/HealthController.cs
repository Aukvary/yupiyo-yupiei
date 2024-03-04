using UnityEngine;

public abstract class HealthController : MonoBehaviour 
{
    protected float health 
    {
        get => health;
        set 
        {
            health = value;
            if (health <= 0)
                Die();
        }
    }

    protected virtual void OnTriggerEnter(Collider col)
    {
        var explosion = col.GetComponent<Explosion>();
        if (explosion != null)
        {
            health -= explosion.damage;
        }
    }

    protected abstract void Die();
}