using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ShowFeedbackPopup(Vector3 _position, int _amount, Color _color, bool isNegative)
    {
        GameObject go = Instantiate(damagePopupPrefab, _position, Quaternion.identity);
        TextMeshPro feedbackUI = go.GetComponent<TextMeshPro>();
        feedbackUI.color = _color;
        
        if(isNegative)
            feedbackUI.SetText($"-{_amount}");
        else
            feedbackUI.SetText($"+{_amount}");
    }

    //public void ShowFeedbackPopup(Vector3 _position, int _amount, bool isHealing)
    //{
    //    GameObject go = Instantiate(damagePopupPrefab, _position, Quaternion.identity);
    //    TextMeshPro feedbackUI = go.GetComponent<TextMeshPro>();
    //    feedbackUI.color = Color.green;

    //    feedbackUI.SetText($"+{_amount}");
    //}




    public void CheckBattleEnd()
    {
        //Logic to end the battle
    }
}
