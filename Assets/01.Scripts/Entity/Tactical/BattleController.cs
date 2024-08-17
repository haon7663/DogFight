using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public HealthBarController healthBarController;
    [SerializeField] private GameObject player; //임시
    
    private void Start()
    {
        healthBarController.Connect(player);
    }
}
