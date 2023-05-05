using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smierc : MonoBehaviour
{
    public EnemieSO pepe;
    int hp;
    Spawner spawn;

    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
        hp = pepe.health;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col);
        if(col.transform.tag == "Bullet")
        {
            hp -= 50;
            check();
        }
    }
    public void zgon()
    {
        spawn.Ecounter -= 1;
        ScoreCounter.Score += 2;
        Destroy(gameObject);
    }void check()
    {
        if(hp <= 0)
        {
            zgon();
        }
    }
}
