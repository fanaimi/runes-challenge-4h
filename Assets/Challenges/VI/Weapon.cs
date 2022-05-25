using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Challenge6;

/// <summary>
/// @gObj   WeaponNumberOne
/// @desc   populates internal members using Scriptable object 
/// </summary>
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponsConfig m_weaponConfig;
    [SerializeField] private string m_name;
    [SerializeField] private int m_damage;
    [SerializeField] private float m_weight;


    // Start is called before the first frame update
    void Start()
    {
        PopulateMembers();

    }

    private void PopulateMembers()
    {
        m_name = m_weaponConfig.m_name;
        m_damage = m_weaponConfig.m_damage;
        m_weight = m_weaponConfig.m_weight;
    }
}

