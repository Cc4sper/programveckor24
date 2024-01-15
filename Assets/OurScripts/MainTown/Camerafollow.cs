using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    public float FollowSpeed = 2f;
    public Transform target;
    public bool camerafollow;
    bool focusing;
    bool death;
    
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
        if (death && cam.orthographicSize > 0)
        {
            GetComponent<Camera>().orthographicSize -= Time.deltaTime * 5;
        }
 
    }
    public void Focus(bool active, float focusScalar)
    {
        if (active && focusing == false)
        {
            cam.orthographicSize /= focusScalar;
            focusing = true;
        }
        else if (active == false && focusing == true)
        {
            cam.orthographicSize *= focusScalar;
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
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -1f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }

    private void ResetCam()
    {
        camerafollow = true;
        death = false;
        cam.orthographicSize = orthoSizeOg;
        
    }
}
