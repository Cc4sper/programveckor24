using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Variables for movement and dash - Casper

    public float moveSpeed = 1.6f;
    float savedSpeed;

    private Animator animator;


    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode vänster;
    [SerializeField] KeyCode höger;

    [SerializeField] TrailRenderer tr;
    [SerializeField] Rigidbody2D rb;

    Vector2 moveDirection;
    Vector2 mousePosistion;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
        UpdateInput();
    }

    public void UpdateInput()
    {

        höger = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 0, ""));
        vänster = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 1, ""));
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 2, ""));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 3, ""));
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(höger))
        {
            moveX = 1;
        }
        else if (Input.GetKey(vänster))
        {
            moveX = -1;
        }
        if (Input.GetKey(up))
        {
            moveY = 1;

        }
        else if (Input.GetKey(down))
        {
            moveY = -1;
        }
        if (moveX != 0 || moveY != 0)

        {
            animator.SetFloat("x", moveX);
            animator.SetFloat("y", moveY);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    public void DisableMove(bool state)
    {
        if (!state)
        {
            savedSpeed = moveSpeed;
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = savedSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));
        Vector2 aimDirection = mousePosistion - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }


}
