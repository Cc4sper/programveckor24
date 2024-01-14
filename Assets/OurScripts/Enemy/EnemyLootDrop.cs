using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootDrop : MonoBehaviour
{
    [SerializeField] Item[] loot;

    public void DropLoot()
    {
        print("dropping loot");
        
        for (int i = 0; i < loot.Length; i++)
        {
            float x = Random.Range(-5, 5) / 10f;
            float y = Random.Range(-5, 5) / 10f;
            print(x +" "+y);
            Vector2 dropPoint = transform.position += new Vector3(x, y);
            Instantiate(loot[i], dropPoint ,Quaternion.identity);
        }
    }
}
