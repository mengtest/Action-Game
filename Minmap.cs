using UnityEngine;
using System.Collections;

public class Minmap : MonoBehaviour
{
    public static Minmap instance;
    public Transform playerIcon;
    public GameObject enemyPrefab;
    private string monsterName = "EnemyIcon";
    private string bossName = "BossIcon";

    void Awake()
    {
        instance = this;
    }

    public Transform GetPlayerIcon()
    {
        return playerIcon;
    }

    public GameObject GetMonsterIcon()
    {
        GameObject go = NGUITools.AddChild(gameObject, enemyPrefab);
        go.GetComponent<UISprite>().spriteName = monsterName;
        return go;
    }

    public GameObject GetBossIcon()
    {
        GameObject go = NGUITools.AddChild(gameObject, enemyPrefab);
        go.GetComponent<UISprite>().spriteName = bossName;
        return go;
    }
}
