using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentTown : MonoBehaviour



{

    [SerializeField] Rigidbody2D body;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode v�nster;
    [SerializeField] KeyCode h�ger;
    [SerializeField] float jumpCD;
    private bool canJump = true;
    bool isJumping;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();      //movement
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up)&& canJump)
        {
            //transform.position += new Vector3(0, 9, 0) * Time.deltaTime;
            // body.AddForce(Vector2.up * 100);
            StartCoroutine(Jumping());
        }


        if (Input.GetKey(v�nster))
        {
            transform.position += new Vector3(-7, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(h�ger))
        {
            transform.position += new Vector3(7, 0, 0) * Time.deltaTime;
        }

       /* if (Input.GetKey(down)) // som s�nker spelaren snabbare, ska g�ra damage n�r collision
        {
            body.AddForce(transform.up * -40);


        }*/


    }

    private IEnumerator Jumping()
    {
        canJump = false;
        isJumping = true;
        body.AddForce(Vector2.up * 500);
        yield return new WaitForSeconds(jumpCD);
        canJump = true;
    }
}
