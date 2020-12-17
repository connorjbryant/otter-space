using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarScript2 : MonoBehaviour
{
    Vector3 localscale;

    // Start is called before the first frame update
    void Start()
    {
        localscale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localscale.x = PlayerOtter1.healthAmount;
        transform.localScale = localscale;
    }
}
