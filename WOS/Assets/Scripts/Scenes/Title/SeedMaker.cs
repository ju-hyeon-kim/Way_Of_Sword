using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMaker : MonoBehaviour
{
    public GameObject Seed;

    private void Start()
    {
        StartCoroutine(MakeSeed());
    }

    IEnumerator MakeSeed()
    {
        while(true)
        {
            GameObject obj = Instantiate(Seed, this.transform);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
