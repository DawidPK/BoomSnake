using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zycie : MonoBehaviour
{
    private void Awake()
    {
        smierc();
    }
    IEnumerator smierc()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
