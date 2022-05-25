using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @gobj   Canvas > Background
/// </summary>
public class SpinLightManager : MonoBehaviour
{
    [SerializeField] private GameObject[] m_spinLights;
    // private bool isToggled = true;

    private void Start()
    {
        // can also do StartCoroutine("FlashLights");
        StartCoroutine(FlashLights());
    }

    IEnumerator FlashLights()
    {
        while (true)
        {             
            yield return new WaitForSeconds(2f);
            //isToggled = !isToggled;    // Debug.Log(flag ? "t" : "f");
            foreach (GameObject go in m_spinLights)
            {
                //go.SetActive(isToggled);
                go.SetActive(!go.activeSelf);
            }
        }
    }


}
