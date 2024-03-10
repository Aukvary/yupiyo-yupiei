using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level
{
    [SerializeField] private float _fireBallDamage;
    [SerializeField] private float _grenadeDamage;
    [SerializeField] private float _needEXP;

    public float fireBallDamage => _fireBallDamage;
    public float grenadeDamage => _grenadeDamage;
    public float needEXP => _needEXP;
}
