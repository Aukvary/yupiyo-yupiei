using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField] private RectTransform _levelBarLink;
    [SerializeField] private TextMeshProUGUI _levelValueLink;
    [SerializeField]private List<Level> _levels;

    private int _currentLevel = 1;
    private float _currentEXP = 0;
    private float _needEXP;

    private FireBallCaster _fireBallCasterLink;
    private GrenadeThrower _grenadeThrowerLink;

    private void Awake()
    {
        _fireBallCasterLink = GetComponent<FireBallCaster>();
        _grenadeThrowerLink = GetComponent<GrenadeThrower>();
    }

    private void Start()
    {
        UpdateLevel(_currentLevel);
        DrawLevelBar();
    }

    public void AddEXP(float exp)
    {
        if (exp < 0 || _currentLevel == _levels.Count)
            return;
        _currentEXP += exp;

        if(_needEXP <= _currentEXP)
        {
            _currentEXP = 0;
            UpdateLevel(_currentLevel + 1);
        }
        DrawLevelBar();
    }

    private void UpdateLevel(int newlevel)
    {
        _currentLevel = newlevel;

        Level level = _levels[newlevel - 1];
        _needEXP = level.needEXP;
        _fireBallCasterLink.damage = level.fireBallDamage;

        _grenadeThrowerLink.enabled = level.grenadeDamage > 0;
        _grenadeThrowerLink.damage = level.grenadeDamage;

    }

    private void DrawLevelBar()
    {
        _levelBarLink.anchorMax = new Vector2(_currentEXP / _needEXP, 1);
        _levelValueLink.text = _currentLevel.ToString();
    }
}
