using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _maxSize = 5;
    [SerializeField] private float _scalingSpeed;
    [SerializeField] private float _damage = 10;

    public float damage
    {
        get => _damage;

        set
        {
            if(value < 0) 
                return;
            _damage = value;
        }
    }
    void Start()
    {
        transform.localScale = Vector3.zero;
    }
    void Update()
    {
        transform.localScale += Vector3.one * _scalingSpeed * Time.deltaTime;
        if (transform.localScale.x > _maxSize == true)
            Destroy(gameObject);
    }
}
