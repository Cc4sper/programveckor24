using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour

{
    //Variables for movement and dash - Casper
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode vänster;
    [SerializeField] KeyCode höger;
    [SerializeField] public float playSpeed = 1.6f;
    [SerializeField] TrailRenderer tr;
    [SerializeField] Rigidbody2D rb;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement and dashing - Casper
        if (isDashing)
        {
            return;
        }
        if (Input.GetKey(vänster))
        {
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime * playSpeed;
        }
        if (Input.GetKey(höger))
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime * playSpeed;
        }
        if (Input.GetKey(up) && transform.position.y < 100)
        {
            transform.position += new Vector3(0, 3, 0) * Time.deltaTime * playSpeed;
        }
        if (Input.GetKey(down) && transform.position.y > -100)
        {
            transform.position += new Vector3(0, -3, 0) * Time.deltaTime * playSpeed;
        }

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());

        }
        if (Input.GetKeyDown(KeyCode.Q) && canDash)
        {
            StartCoroutine(Dash2());

        }
    }
    //function for dashing right - Casper
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        if (isDashing == false)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    //function for dashing left - Casper
    private IEnumerator Dash2()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        if (isDashing == false)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
