using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class znikanie : MonoBehaviour
{
    public enum rarity
    {
        common,
        rare,
        legendary
    }
    public rarity Rarity;
    Spawner spawn;
    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            spawn.Fcounter -=1;
            Destroy(gameObject);
        }
    }
}
