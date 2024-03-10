using UnityEngine;
using UnityEngine.Rendering;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private Rigidbody _grenade;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _force;

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

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) == false)
            return;
        var grenade = Instantiate(_grenade, _spawnPosition.position, _spawnPosition.rotation);
        grenade.GetComponent<Rigidbody>().AddForce((_spawnPosition.forward + Vector3.up) * _force);
        grenade.GetComponent<Grenade>().damage = _damage;

    }
}
