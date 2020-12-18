using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;

    private float timeToSpawn = 2f;

    // Update is called once per frame
    void Update()
    {
        if (GameController.current.PlayerIsAlive)
        {
            if (timeToSpawn <= 0)
            {
                Instantiate(coin, transform.position + new Vector3(0, Random.Range(0, 2), 0), transform.rotation);
                timeToSpawn = 2f;
            }
            else
            {
                timeToSpawn -= Time.deltaTime;
            }
        }        
    }
}
