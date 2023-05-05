using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderKill : MonoBehaviour
{
    public GameOver playerDed;
    void OnCollisionEnter2D(Collision2D col)
        {
            switch (col.transform.tag)
            {
                case "Player":
                    StartCoroutine(playerDed.Death());
                    break;
                default:
                    break;
            }
            
            // if(col.transform.tag == "Player"){
            //     return false;
            // }else{
            //     return true;
            // }
        }
}
