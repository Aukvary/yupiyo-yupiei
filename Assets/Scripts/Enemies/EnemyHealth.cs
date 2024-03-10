using UnityEngine;

public class EnemyHealth : HealthController
{
    [SerializeField] private PlayerLevelController _playerLevelLink;
    [SerializeField] private float _exp;

    private void OnCollisionEnter(Collision col)
    {
        var fireball = col.gameObject.GetComponent<FireBall>();
        if (fireball != null)
            DealDamage(fireball.damage);
    }

    public override void DealDamage(float damge)
    {
        /*base.DealDamage(damge);*/
        _playerLevelLink.AddEXP(_exp);
    }


    protected override void Die()
    {
        Destroy(gameObject);
    }
}
