using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsController : MonoBehaviour
{

    [SerializeField] private Transform[] m_fragments = new Transform[8];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveFragments()
    {
        foreach (Transform fragment in m_fragments)
        {
            Renderer rend = fragment.GetComponent<Renderer>();
            StartCoroutine(ShootFragment(fragment, fragment.forward, rend, 3f));

        }

    }


    IEnumerator ShootFragment(
        Transform fragment,
        Vector3 direction,
        Renderer rend,
        float duration
    )
    {
        print("shooting fragments");
        float elapsedTime = 0;
        float startTime = Time.time;

        Vector3 startingPos = fragment.position;
        Vector3 finalPos = fragment.position + (direction * 5);
        Color startCol = rend.material.color;
        Color endCol = Color.clear;


        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;
            fragment.position = Vector3.Lerp(startingPos, finalPos, progress);
            rend.material.color = Color.Lerp(startCol, endCol, progress);
            transform.localScale = Vector3.Lerp(
                new Vector3(1, 1, 1),
                new Vector3(0.01f, 0.01f, 0.01f),
                progress
            );
            elapsedTime = Time.time - startTime;
            yield return null;
        }
    }

}
