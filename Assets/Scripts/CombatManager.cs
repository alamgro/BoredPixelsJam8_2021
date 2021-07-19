using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    #region SINGLETON MANAGER
    public static CombatManager Manager { get { return _instance; } }

    private static CombatManager _instance;
    #endregion

    private void Awake()
    {
        //Time.timeScale = 1.0f;
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public static List<Enemy> enemies = new List<Enemy>(); //List of enemies
    public static List<Hero> heroes = new List<Hero>(); //List of heroes
    [SerializeField]
    private GameObject damagePopupPrefab; //Damage Text prefab

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

    public void ShowDamagePopup(Vector3 _position, int _dmgTaken)
    {
        GameObject go = Instantiate(damagePopupPrefab, _position, Quaternion.identity);
        TextMeshPro damamgeUI = go.GetComponent<TextMeshPro>();
        damamgeUI.SetText($"-{_dmgTaken}");
    }

    public void CheckBattleEnd()
    {
    }
}
