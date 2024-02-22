using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTeleprt : MonoBehaviour
{
    [SerializeField] bool SideScrollarTransition;
    [SerializeField] bool Cold;
    [SerializeField] AudioClip newMusic;
    Transform teleportPoint;
    Transform player;
    Camera cam;
    PostProcessEdit post;
    
    private void Start()
    {
        teleportPoint = transform.GetChild(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform.parent;
            
            player.GetComponent<PlayerHealth>().screen.GetComponent<DarkScreen>().ScreenFade(true);
            if (newMusic != null)
            {
                music.Instance.SwitchMusic(newMusic, 2);
            }
            Invoke("Teleport", 1f);
            if (SideScrollarTransition)
            {
                player.GetComponent<PlayerCamera>().ActivateSideScrollar();
            }
            else
            {
                player.GetComponent<PlayerCamera>().InactivateSideScrollar();
            }
            getPostProcess();
            if (Cold)
            {
                post.ChangeTemprature(-5);
                post.ChangeBloom(5);
                
            }
            else
            {
                post.ChangeTemprature(5);
                post.ChangeBloom(25);
            }
        }
    }
    private void getPostProcess()
    {
        if (cam == null)
        {
            cam = player.GetComponent<PlayerCamera>().cam;
            post = cam.GetComponent<PostProcessEdit>();
        }
    }

    private void Teleport()
    {
        player.position = teleportPoint.transform.position;
        //player.GetComponent<PlayerMove>().DisableMove(false);
    }
}
