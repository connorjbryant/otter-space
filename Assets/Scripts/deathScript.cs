using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScript : MonoBehaviour
{
    //public bool HasDied;

    public GameObject GameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerOtter.healthAmount <= 0 && PlayerOtter1.healthAmount <= 0)
        {
            GameOverMenu.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
            else
            {
                Debug.Log("Press R or Q");
            }
        }
        else
        {
            GameOverMenu.SetActive(false);
        }
    }
}
