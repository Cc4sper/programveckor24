using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyhp;
    public bool vulnerable = true;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("damage"))
        {
            int damagetaken;
            damagetaken = collision.GetComponent<GenericAttack>().damage;
            if (vulnerable)
            {
                enemyhp -= damagetaken;
                checkkdeath();
            }
        }
    }
    void checkkdeath()
    {
        if (enemyhp < 1)
        {
            Destroy(gameObject);
            print("deadasss");
        }
    }
}
