using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private Rigidbody _grenade;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _force;

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

    }
}
