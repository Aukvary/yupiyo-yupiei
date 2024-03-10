using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _damage = 50;
    [SerializeField] private float _delay = 3;
    [SerializeField] private GameObject _explosion;

    public float damage
    {
        get => _damage;
        set
        {
            if (value < 0)
                return;
            _damage = value;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        Invoke("Explosion", _delay);
    }

    private void Explosion()
    {
        var explosion =  Instantiate(_explosion, transform.position, transform.rotation);
        explosion.GetComponent<Explosion>().damage = _damage;
        Destroy(gameObject);
    }
}
