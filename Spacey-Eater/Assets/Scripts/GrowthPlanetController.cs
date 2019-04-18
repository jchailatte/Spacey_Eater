using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthPlanetController : MonoBehaviour
{
    // Start is called before the first frame update
    public float growthRate;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //public void grow()
        //{
        //    transform.localScale += new Vector3(growthRate, growthRate, 0f);
        //}

}
