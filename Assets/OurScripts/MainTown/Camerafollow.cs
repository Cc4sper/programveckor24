using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public float height;
    public Transform target;
    public bool camerafollow;
    bool focusing;
    bool death;
    public int activeSize;
    
    float orthoSizeOg;

    private Camera cam;



    // Start is called before the first frame update
    void Start()
    {
        camerafollow = true;
        orthoSizeOg = GetComponent<Camera>().orthographicSize;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camerafollow == true)
        {
            camerafollowing();
        }
        if (death && cam.orthographicSize > 0.5f)
        {
            GetComponent<Camera>().orthographicSize -= Time.deltaTime * 5;
        }
        if (focusing && cam.orthographicSize > activeSize)
        {
            cam.orthographicSize -= Time.deltaTime * 10;
        }
        else if (death == false && cam.orthographicSize < activeSize - 0.1f)
        {
            focusing = false;
            cam.orthographicSize += Time.deltaTime * 10;
        }
       
        
        
       
 
    }
    public void Focus(bool active, int newSize)
    {
        activeSize = newSize;
        if (active && focusing == false)
        {
            focusing = true;
        }
        else if (active == false && focusing == true)
        {
            focusing = false;
        }
    }
    public void deathEffect()
    {
        death = true;
        Invoke("ResetCam", 1);
        
    }


    public void camerafollowing()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + height, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    private void ResetCam()
    {
        camerafollow = true;
        cam.orthographicSize = activeSize;
        death = false;
        
        
    }
}
