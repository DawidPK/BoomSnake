// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class sprawdzanieCzy : MonoBehaviour
// {
//     NewEnemyState czyJest;
//     void Awake()
//     {
//         czyJest = transform.parent.gameObject.GetComponent<NewEnemyState>(); 
//     }
//     bool czyJestWpoblizu(){
//         void OnTriggerEnter2D(Collider2D col)
//         {
//             if(col.transform.tag == "Player"){
//                 return false;
//             }else{
//                 return true;
//             }
//         }
//     }
//     void Update()
//     {
//         czyJest.isPlayerClose = czyJestWpoblizu()
//     }
// }
