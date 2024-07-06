using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public int enemies = 5;
    public Text enemiesText;

    private void Awake()
    {
        enemiesText.text = enemies.ToString();

        EnemyBehaviour.OnEnemyKilled += OnEnemyKilledAction;
    }

    void OnEnemyKilledAction()
    {
        enemies--;
        enemiesText.text = enemies.ToString();
    }
}
