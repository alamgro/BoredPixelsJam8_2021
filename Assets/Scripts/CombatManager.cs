using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static List<Enemy> enemies = new List<Enemy>(); //List of enemies
    public static List<Hero> heroes = new List<Hero>(); //List of heroes

    void Start()
    {
        
    }

    void Update()
    {
        print("Heroes = " + heroes.Count);
        print("Enemies = " + enemies.Count);
    }
}
