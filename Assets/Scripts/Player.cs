using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rig;
    public float JumpForce;
    private bool isJumping;
    public GameObject bullet;
    public Transform firePoint;
    public GameObject smoke;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Lógica para movimentação do player
        rig.velocity = new Vector2(Speed * Time.deltaTime, rig.velocity.y);

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isJumping = true;
            smoke.SetActive(true); // Ativar fumaça do jetpack
        }
        if (Input.GetKey(KeyCode.Z))
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            smoke.SetActive(false);
        }
    }
}
