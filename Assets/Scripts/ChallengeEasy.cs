using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// @gObj   ChallengeEasy
/// @desc   this will find max value and its index from a given array 
///         and run every 3 seconds
///         
/// @sol1   FindMaxValueAndIndexNoLoops :)
/// @sol2   FindMaxValueAndIndexWithLoops 
/// </summary>
public class ChallengeEasy : MonoBehaviour
{
    [SerializeField] int[] m_numArray = new int[5];


    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating( "FindMaxValueAndIndexNoLoops" , 0f, 3f);
        InvokeRepeating( "FindMaxValueAndIndexWithLoops" , 0f, 3f);
    }


    private void FindMaxValueAndIndexNoLoops()
    {
        int maxVal = Mathf.Max(m_numArray);
        int index = System.Array.IndexOf(m_numArray, maxVal);
        Debug.Log($"The max value is {maxVal} and its index is {index}.");
        int newRandom = Random.Range(0, 99);
        m_numArray[index] = newRandom;
    }

    private void FindMaxValueAndIndexWithLoops()
    {
        int maxVal = m_numArray[0], index = 1;

        for (int i=1; i< m_numArray.Length; i++)
        {
            if (m_numArray[i] > maxVal)
            {
                maxVal = m_numArray[i];
                index = i;
            }
        }

        Debug.Log($"The max value is {maxVal} and its index is {index}.");
        int newRandom = Random.Range(0, 99);
        m_numArray[index] = newRandom;
    }


}
  