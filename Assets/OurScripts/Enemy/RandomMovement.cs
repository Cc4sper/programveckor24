using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

   [SerializeField] float speed;
   [SerializeField] float range;
   [SerializeField] float maxDistance;

    Vector2 waypoint;
    Vector3 OgPos;


    // Start is called before the first frame update
    void Start()
    {
        OgPos = transform.position;
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint) < range)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        waypoint = new Vector2(OgPos.x + Random.Range(-maxDistance, maxDistance), OgPos.y + Random.Range(-maxDistance, maxDistance));
    }
}
