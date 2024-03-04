using UnityEngine;

class PlayerHealth : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float _health = 100;
    [SerializeField] private RectTransform _currentHealth;

    [Header("UI Settings")]
    [SerializeField] private GameObject _gamePlayerUI;
    [SerializeField] private GameObject _deathUI;

    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
    }

    private void Start()
    {
        DrawHealthBar();
    }

    private void DrawHealthBar() =>
        _currentHealth.anchorMax = new Vector2(_health / _maxHealth, 1);

    public void DealDamage(float damage)
    {
        _health -= Mathf.Clamp(damage, 0, int.MaxValue);

        if(_health <= 0)
        {
            Die();
        }

       DrawHealthBar();
    }

    private void Die()
    {
        _deathUI.SetActive(true);
        _gamePlayerUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCaster>().enabled = false;
        GetComponent<PlayerCamera>().enabled = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        var healer = col.gameObject.GetComponent<HealthKit>();
        var explosion = col.gameObject.GetComponent<Explosion>();
        if (healer != null)
        {
            _health = Mathf.Clamp(_health + healer.healValue, 0, _maxHealth);
            Destroy(healer);
            DrawHealthBar();
        }

        if(explosion != null)
        {
            DealDamage(explosion.damage);
        }
            
    }
}