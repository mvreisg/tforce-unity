using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private Transform backPoint;
    private Animator animator;
    private Rigidbody2D rig;

    private void Start()
    {
        backPoint = GameObject.Find("BackPoint").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.current.PlayerIsAlive)
        {
            // Mesma lógica da bala só que para a esquerda

            rig.velocity = new Vector2(-Random.Range(minSpeed, maxSpeed), rig.velocity.y);

            if (transform.position.x < backPoint.position.x)
            {
                Destroy(gameObject);
            }
        }        
    }

    // Método para verificar colisao da bala no inimigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se o inimigo bateu na bala
        if (collision.gameObject.tag.Equals("bullet"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GameController.current.AddScore(10); // Ao matar o inimigo, ganha 10 moedas
            animator.SetTrigger("destroy");
            Destroy(gameObject, 1f);
        }
    }
}
