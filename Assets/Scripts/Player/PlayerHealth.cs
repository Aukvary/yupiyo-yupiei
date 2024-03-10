using UnityEngine;

class PlayerHealth : HealthController
{
    [Header("Player Settings")]
    [SerializeField] private RectTransform _currentHealth;

    [Header("UI Settings")]
    [SerializeField] private GameObject _gamePlayerUI;
    [SerializeField] private GameObject _deathUI;

    private float _maxHealth;

    private void Awake()
    {
        _maxHealth = health;
    }

    private void Start()
    {
        DrawHealthBar();
    }

    private void DrawHealthBar() =>
        _currentHealth.anchorMax = new Vector2(health / _maxHealth, 1);

    public override void DealDamage(float damage)
    {
       base.DealDamage(damage);
       DrawHealthBar();
    }

    protected override void Die()
    {
        _deathUI.SetActive(true);
        _gamePlayerUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireBallCaster>().enabled = false;
        GetComponent<PlayerCamera>().enabled = false;
    }

    protected override void OnTriggerEnter(Collider col)
    {
        var healer = col.gameObject.GetComponent<HealthKit>();
        if (healer != null)
        {
            health = Mathf.Clamp(health + healer.healValue, 0, _maxHealth);
            Destroy(healer.gameObject);
            DrawHealthBar();
        }

/*        var explosion = col.gameObject.GetComponent<Explosion>();
        if (explosion != null)
        {
            DealDamage(explosion.damage);
        }*/

    }
}