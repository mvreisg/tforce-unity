using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float Speed; // Velocidade da câmera
    private GameObject player; // Player
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Camera seguindo o player
        Vector3 newPosition = new Vector3(player.transform.position.x + 5f, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, Speed * Time.deltaTime); // Efeito suave
    }
}
