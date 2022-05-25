using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Challenge6;
using System;

/// <summary>
/// @gObj   ChestNumberOne
/// @desc   populates internal members using Scriptable object and returns 
///             random weapon according to given percent values
/// </summary>
public class Chest : MonoBehaviour
{
    [SerializeField] private ChestConfig m_chestOne;
    [SerializeField] private string m_rewardWeapon;
    [SerializeField] private List<string> m_weapons;
    [SerializeField] private List<int> m_pecents;
    [SerializeField] private Dictionary<string, int> m_weaponsAndPercents = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        PopulateLists();
        PopulateWeaponsAndPercents(); // UNNECESSARY, JUST PRACTICE
        m_rewardWeapon = PickRandomWeapon();

    }


    private void PopulateLists()
    {
        m_weapons = m_chestOne.m_weapons;
        m_pecents = m_chestOne.m_pecents;
    }

    private void PopulateWeaponsAndPercents()
    {
        for (int i = 0; i < m_weapons.Count; i++)
        {
            m_weaponsAndPercents.Add(m_weapons[i], m_pecents[i]);
        }
        //Debug.Log(m_weaponsAndPercents["dap"]);
    }


    private string PickRandomWeapon()
    {
        int maxPercent = 100;
        int i = 0;
        int total = 0;
        int rand = UnityEngine.Random.Range(0, maxPercent);
        for (i = 0; i < m_pecents.Count; i++)
        {
            total += m_pecents[i];
            if (total >= rand) break;
        }
        Debug.Log(i);
        return m_weapons[i];

    }


}
