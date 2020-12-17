using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipScript : MonoBehaviour
{
    public bool rocketShip;

    public static int coinCount = 0;

    public GameObject showShip;

    // Use this for initialization
    void Start()
    {
        showShip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (coinCount >= 6)
        {
            showShip.SetActive(true);
        }
    }
}
