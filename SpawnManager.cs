using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public AudioClip victoryClip;
    public EnemySpawn[] monsterArray;
    public EnemySpawn[] bossArray;
    public List<GameObject> enemyList = new List<GameObject>();
    public UISprite win;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (MenuController.instance.gameType == GameType.Easy)
        {
            StartCoroutine(SpawnEasy());
        }
        else if (MenuController.instance.gameType == GameType.Endless)
        {
            StartCoroutine(SpawnEndless());
        }
    }

    IEnumerator SpawnEasy()  //普通模式
    {
        //第一波敌人
        foreach (EnemySpawn es in monsterArray)
        {
            GameObject go = es.Spawn();
            enemyList.Add(go);
        }
        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第二波敌人
        foreach (EnemySpawn es in monsterArray)
        {
            GameObject go = es.Spawn();
            enemyList.Add(go);
        }
        yield return new WaitForSeconds(1.0f);
        foreach (EnemySpawn es in monsterArray)
        {
            GameObject go = es.Spawn();
            enemyList.Add(go);
        }
        yield return new WaitForSeconds(1.0f);
        foreach (EnemySpawn es in monsterArray)
        {
            GameObject go = es.Spawn();
            enemyList.Add(go);
        }
        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //第三波敌人
        foreach (EnemySpawn es in bossArray)
        {
            GameObject go = es.Spawn();
            enemyList.Add(go);
        }
        yield return new WaitForSeconds(0.5f);
        foreach (EnemySpawn es in bossArray)
        {
            GameObject go = es.Spawn();
            enemyList.Add(go);
        }
        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        //游戏胜利
        AudioSource.PlayClipAtPoint(victoryClip, transform.position, 0.25f);
        win.gameObject.SetActive(true);
    }

    IEnumerator SpawnEndless()  //无尽模式
    {
        while (true)
        {
            foreach (EnemySpawn es in bossArray)
            {
                GameObject go = es.Spawn();
                enemyList.Add(go);
            }
            yield return new WaitForSeconds(10.0f);
        }
    }
}
