using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    //Variables for movement and dash - Casper

    public float moveSpeed = 1.6f;

    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] KeyCode up;
    [SerializeField] KeyCode down;
    [SerializeField] KeyCode vänster;
    [SerializeField] KeyCode höger;
    [SerializeField] KeyCode Ability1;

    [SerializeField] TrailRenderer tr;
    [SerializeField] Rigidbody2D rb;

    Vector2 moveDirection;
    Vector2 mousePosistion;


    // Start is called before the first frame update
    void Start()
    {
        höger = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 0, ""));
        vänster = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 1, ""));
        up= (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 2, ""));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CustomKey" + 3, ""));
    } 

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosistion = Camera.main.ScreenToWorldPoint(Input.mousePosition);


    }


    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));

        Vector2 aimDirection = mousePosistion - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }


}
