using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float _delay = 3;
    [SerializeField] private GameObject _explosion;
    private void OnCollisionEnter(Collision col)
    {
        Invoke("Explosion", _delay);
    }

    private void Explosion()
    {
        Instantiate(_explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
