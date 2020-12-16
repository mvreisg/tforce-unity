using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
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
        // Mesma lógica da bala só que para a esquerda
        //transform.Translate(Vector3.left * Speed * Time.deltaTime);

        rig.velocity = new Vector2(-Speed, rig.velocity.y);

        if (transform.position.x < backPoint.position.x)
        {
            Destroy(gameObject);
        }
    }

    // Método para verificar colisao da bala no inimigp
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se o inimigo bateu na bala
        if (collision.gameObject.tag.Equals("bullet"))
        {
            animator.SetTrigger("destroy");
            Destroy(gameObject, 1f);
        }
    }
}
