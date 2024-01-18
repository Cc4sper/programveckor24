using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTeleprt : MonoBehaviour
{
    [SerializeField] bool SideScrollarTransition;
    Transform teleportPoint;
    Transform player;
    
    private void Start()
    {
        teleportPoint = transform.GetChild(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform.parent;
            //Instantiate(worldLoad, loadWorld.position - transform.position, Quaternion.identity);
 
            player.GetComponent<PlayerHealth>().screen.GetComponent<DarkScreen>().ScreenFade();
            player.GetComponent<PlayerMove>().DisableMove(true);
            Invoke("Teleport", 0.9f);
            if (SideScrollarTransition)
            {
                player.GetComponent<PlayerCamera>().ActivateSideScrollar();
            }
            else
            {
                player.GetComponent<PlayerCamera>().InactivateSideScrollar();
            }
        }
    }

    private void Teleport()
    {
        player.position = teleportPoint.transform.position;
        player.GetComponent<PlayerMove>().DisableMove(false);
    }
}
