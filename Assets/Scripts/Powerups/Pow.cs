using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pow : MonoBehaviour
{
    [SerializeField] public PowerUpConfig m_powerUp;



    private void Start()
    {
        Debug.Log(m_powerUp.m_powerUpName);
        // if(m_powerUp.m_powerUpType)
    }


}
