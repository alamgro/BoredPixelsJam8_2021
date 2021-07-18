using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static List<Enemy> enemies = new List<Enemy>(); //List of enemies
    public static List<Hero> heroes = new List<Hero>(); //List of heroes

    void Start()
    {
        print("Heroes = " + heroes.Count);
        print("Enemies = " + enemies.Count);
    }

    void Update()
    {
        ///Debug
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (Enemy item in enemies)
            {
                print(item.unitName);
            }
        }

    }

    public void CheckBattleEnd()
    {
    }
}
