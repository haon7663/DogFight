using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : Singleton<BattleController>
{
    public Player player;
    
    public HealthBarController healthBarController;
    public DamageHudController damageHudController;

    public int killCount;
    
    private void Start()
    {
        healthBarController.Connect(player.gameObject);
    }

    public void TimeStop()
    {
        Time.timeScale = 0.001f;
    }

    public void LoadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNames.InGameScene);
    }
}
