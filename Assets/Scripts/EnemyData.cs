using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewEnemy")]
public class EnemyData : ScriptableObject
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public Sprite enemySprite;
    public Color enemyColor;
}
