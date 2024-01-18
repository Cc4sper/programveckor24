using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemTrigger : MonoBehaviour
{
    [SerializeField] Item drop;
    public float cooldown;
    bool active;
    float timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = true;
            timer = cooldown;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = false;
        }
    }

    public void Update()
    {
        if (active)
        {
            if (timer>0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                DropItem();
            }
        }
    }
    void DropItem()
    {
        timer = cooldown + Random.Range(-cooldown/2,cooldown/2);
        Instantiate(drop, transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2)), Quaternion.identity);
    }
}
