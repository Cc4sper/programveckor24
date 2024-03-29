using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Variables for movement and dash - Casper

    public float moveSpeed = 1.6f;
    float savedSpeed;
    public bool climb;
    public bool sideScrollar;

    public Animator animator;


    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode v�nster;
    [SerializeField] KeyCode h�ger;

    [SerializeField] TrailRenderer tr;
    [SerializeField] Rigidbody2D rb;

    Vector2 moveDirection;
    Vector2 mousePosistion;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        tr = GetComponent<TrailRenderer>();
        UpdateInput();
    }

    public void UpdateInput()
    {

        h�ger = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 0, "D"));
        v�nster = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 1, "A"));
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 2, "W"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 3, "S"));
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(h�ger))
        {
            moveX = 1;
        }
        else if (Input.GetKey(v�nster))
        {
            moveX = -1;
        }
        if (Input.GetKey(up) && sideScrollar == false)
        {
            moveY = 1;

        }
        else if (Input.GetKey(down) && sideScrollar == false)
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
        if (state && moveSpeed != 0) //makes sure we dont accidently save a disabled speed
        {
            savedSpeed = moveSpeed;
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = savedSpeed;
        }
    }

    public void Slowed(bool state)
    {
        if (state) //slow effect halves players movement
        {
            moveSpeed /= 2;
        }
        else
        {
            moveSpeed *= 2;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));
        Vector2 aimDirection = mousePosistion - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.transform.eulerAngles = new Vector3(0,0,aimAngle);
    }


}
