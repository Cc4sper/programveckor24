using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveSummon : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject[] robots;
    bool active;
    public void Summon(int amount)
    {
        robots = new GameObject[amount];
        for (int i = 0; i < amount; i++)
        {
             robots[i] = Instantiate(prefab, transform.position + new Vector3(Random.Range(-2, 3), Random.Range(-2, 3)), Quaternion.identity);
        }
        active = true;
       
    }

    private void Update()
    {
        if (active)
        {
            if (!CheckAlive())
            {
                broken();
            } 
        }
    }
    bool CheckAlive()
    {
        for (int i = 0; i < robots.Length; i++)
        {
            if (robots[i] == true)
            {
                return true;
            }
        }
        return false;
    }
    void broken()
    {
        print("next phase");
        active = false;
        GetComponent<BossHealth>().Return();
    }
}
