using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using a namespace
using MusicalRunes;

// creating our namespace
namespace MusicalRunes
{

    public enum PowerUpType
    { 
        hint, replay, bloodSacrifice, lifeUpgrade 
    }


    /// <summary>
    /// @gObj       
    /// </summary>
    public class PowerUpManager : MonoBehaviour
    {

        [SerializeField] PowerUpType pType;

        //private void Start()
        //{
        //    if (pType == PowerUpType.hint) { }
        //}

    } // PowerUpManager

} // namespace


