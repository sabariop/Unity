using System.Collections;
using System.Collections.Generic;
// GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EnemyAI enemyAI;

    void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
    }

    void Update()
    {
        enemyAI.UpdateAI();
    }
}