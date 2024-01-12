using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public Transform target;
    public bool camerafollow;



    // Start is called before the first frame update
    void Start()
    {
        camerafollow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (camerafollow == true)
        {
            camerafollowing();
        }
        else
        {
            
        }



    }

    public void camerafollowing()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -1f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
