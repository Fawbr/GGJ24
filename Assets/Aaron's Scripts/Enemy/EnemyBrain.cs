using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyBrain : MonoBehaviour
{
    [SerializeField] public EnemyAI[] enemyList;
    [SerializeField] SceneChanger sceneChanger;
    bool check = true;
    List<int> enemiesToBeActivated = new List<int>();
    [SerializeField] List<EnemyAI> enemyAIList = new List<EnemyAI>();
    EnemyAI enemyAI;
    int randomStart;
    float time;
    bool switchAggressiveState;
    void OnEnable()
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
        if (check)
        {
            foreach (EnemyAI enemy in enemyList)
            {
                if (enemy.enabled == true)
                {
                    enemyAIList.Add(enemy);
                }
            }
            check = false;
        }
        if (enemyAIList.Count != 0)
        {
            time += Time.deltaTime;
            if (time > Random.Range(10, 20))
            {
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
                check = true;
            }
        }
        else
        {
            sceneChanger.FadeToScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public void RemoveFromBrain()
    {
        enemyAIList.Clear();
        foreach (EnemyAI enemy in enemyList)
        {
            if (enemy.enabled == true)
            {
                enemyAIList.Add(enemy);
            }
        }
    }
}
