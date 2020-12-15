﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject Platform; // Plataforma
    public Transform point; // ponto onde acaba a câmera
    public float Distance; // distância entre as plataformas

    private float platformWidth;

    void Start()
    {
        if (Platform.GetComponent<BoxCollider2D>())
        {
            // pegando o tamanho do colisor
            platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;
        }
        else
        {
            // Pegando tamanho do colisor com formas diferentes
            platformWidth = Platform.GetComponent<PolygonCollider2D>().bounds.size.x;
        }
    }

    void Update()
    {
        // Lógica para gerar plataformas se objeto estiver fora da camera
        if (transform.position.x < point.position.x)
        {
            Distance = Random.Range(3f, 8f);

            // Gera nova plataforma
            transform.position = new Vector3(transform.position.x + platformWidth + Distance, transform.position.y, transform.position.z);

            // Instanciando nova plataforma na cena
            Instantiate(Platform, transform.position, transform.rotation);
        }
    }
}
