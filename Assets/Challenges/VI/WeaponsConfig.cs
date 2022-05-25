using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge6
{

    [CreateAssetMenu(fileName = "Weapons Config", menuName = "Configs/Weapon", order = 1)]
    public class WeaponsConfig : ScriptableObject
    {
        public string m_name;
        public int m_damage;
        public float m_weight;
        public enum DamageType { bludgeoning, piercing, slashing };
        public DamageType m_damageType;
    }

} // namespace