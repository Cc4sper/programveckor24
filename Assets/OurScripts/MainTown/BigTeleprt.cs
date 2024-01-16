using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTeleprt : MonoBehaviour
{
    [SerializeField] GameObject worldLoad;
    [SerializeField] Transform loadWorld;
    Transform teleportPoint;
    GameObject colidedObj;
    private void Start()
    {
        teleportPoint = transform.GetChild(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colidedObj = collision.gameObject;
            Instantiate(worldLoad, loadWorld.position, Quaternion.identity);
            collision.transform.parent.GetComponent<PlayerHealth>().screen.GetComponent<DarkScreen>().ScreenFade();
            Invoke("Teleport", 0.9f);
        }
    }

    private void Teleport()
    {
        colidedObj.transform.parent.position = teleportPoint.transform.position;
    }
}
