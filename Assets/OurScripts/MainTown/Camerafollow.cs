using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public float height;
    public Transform target;
    public bool camerafollow;
    public float zoomSpeed;
    bool focusing;
    bool death;
    public float activeSize;
    
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
            cam.orthographicSize -= Time.deltaTime * zoomSpeed * 2;
        }
        if (focusing && cam.orthographicSize > activeSize)
        {
            cam.orthographicSize -= Time.deltaTime * zoomSpeed;
        }
        else if (death == false && cam.orthographicSize < activeSize - 0.1f)
        {
            focusing = false;
            cam.orthographicSize += Time.deltaTime * zoomSpeed;
        }
       
        
        
       
 
    }
    public void Focus(bool active, float newSize)
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
    public void SetCamera(float size)
    {
        if (cam != null)
        {
            cam.orthographicSize = size;
        }
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
