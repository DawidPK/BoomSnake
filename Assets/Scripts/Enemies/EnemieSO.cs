using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemieSO : ScriptableObject
{
    public string EnemyName;

    public int health;
    public float speed;
    public float targetRange;

    public Sprite model;
}
