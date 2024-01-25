using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] EnemyAI[] enemyList;
    List<int> enemiesToBeActivated = new List<int>();
    List<EnemyAI> enemyAIList = new List<EnemyAI>();
    EnemyAI enemyAI;
    int randomStart;
    float time;
    bool switchAggressiveState;
    void Start()
    {
        enemyList = GetComponentsInChildren<EnemyAI>();
        for (int x = 0; x <= (enemyList.Length / 2); x++)
        {
            enemyList[Random.Range(0, enemyList.Length)].isAggressive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > Random.Range(10, 20))
        {
            enemyList = GetComponentsInChildren<EnemyAI>();
            foreach (EnemyAI enemy in enemyList)
            {
                if (enemy.enabled == true)
                {
                    enemyAIList.Add(enemy);
                }
            }

            for (int x = 0; x <= (enemyAIList.Count / 2); x++)
            {
                switchAggressiveState = enemyAIList[Random.Range(0, enemyAIList.Count)].isAggressive;
                enemyAI = enemyAIList[Random.Range(0, enemyAIList.Count)];
                enemyAI.isAggressive = !enemyAI.isAggressive;
                if (enemyAI.isAggressive == false)
                {
                    enemyAI.NewNode();
                }
            }
            time = 0f;
            enemyAIList.Clear();
        }
    }
}
