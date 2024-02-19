using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

   [SerializeField] float speed;
   [SerializeField] float range;
   [SerializeField] float maxDistance;

    public Animator animator;
    Vector2 waypoint;
    Vector3 OgPos;

    Vector3 lastPos;

    private void OnEnable() //re-enabled when it is not chasing, works as a reset for it's movement & animation
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            OgPos = transform.position;
        }
        SetNewDestination();
    }
    
    void Update()
    {
    
        lastPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint) < range)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        float newPosX = Random.Range(-maxDistance, maxDistance);
        float newPosY = Random.Range(-maxDistance, maxDistance);
        animator.SetFloat("x", newPosX);
        animator.SetFloat("y", newPosY);

        waypoint = new Vector2(OgPos.x + newPosX, OgPos.y + newPosY);
    }
}
