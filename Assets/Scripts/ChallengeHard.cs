using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// @gObj   ChallengeHard
/// @desc   this uses bubble sorting algorithm to sort given array 
///             swapping 2 elements at a time    
/// @note   interesting to read about how to optimise it using a 
///             boolean flag        
/// </summary>
public class ChallengeHard : MonoBehaviour
{
    [SerializeField] int[] m_numArray = { 99, -5, 60, -12, 33, 3, -80 };


    // Start is called before the first frame update
    void Start()
    {
        BubbleSortArray(m_numArray);
    }

    /// <summary>
    /// bubble sorting
    /// </summary>
    /// <param name="arrayToSort">array of numbers to sort</param>
    private void BubbleSortArray(int[] arrayToSort)
    {
        int len = arrayToSort.Length;

        for (int i=0; i<len-1; i++ )
        {
            bool coupleSorted = false;

            for (int j=0; j<len-i-1; j++) 
            {
                if (arrayToSort[j] > arrayToSort[j + 1])
                {
                    int temp = arrayToSort[j];
                    arrayToSort[j] = arrayToSort[j + 1];
                    arrayToSort[j + 1] = temp;
                    coupleSorted = true;
                }
            }

            if (!coupleSorted) break;

        }
        LogResults(arrayToSort);
    }

    /// <summary>
    /// this joins given array and prints result and time
    /// </summary>
    /// <param name="arrayToLog"></param>
    private void LogResults(int[] arrayToLog)
    {
        string arrStr = String.Join(", ", arrayToLog);
        Debug.Log($"Sorted array is [{arrStr}], sorted in {Time.time}");
        // Sorted array is [-80, -12, -5, 3, 33, 60, 99], sorted in 0
    }
}
  