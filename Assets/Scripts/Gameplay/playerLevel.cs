﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLevel : MonoBehaviour
{
    public static int playerLvl;
    public int xpMod;
    public int xpRequired;
    public static int xpCurrent;

    public Slider xpSlider;
    public Text xpText;
    public Text levelText;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerLvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        xpSlider.maxValue = xpRequired;
        xpSlider.value = xpCurrent;
        xpText.text = xpCurrent + " / " + xpRequired;
        levelText.text = "Level " + playerLvl;

        if(xpCurrent >= xpRequired)
        {
            LevelUp();
        }

        if(Input.GetKeyDown(KeyCode.L)) //Dummy function to test Levelling functionality
        {
            GiveXP(500);
        }
    }

    public static void GiveXP(int XPToGive) //Function to give XP
    {
        xpCurrent += XPToGive;
    }

    void LevelUp() //Function to level player up
    {
        playerLvl++;
        xpCurrent -= xpRequired;
        xpRequired *= xpMod;

        enemy.GetComponent<EnemyScript>().enemyHP += 2;
        enemy.GetComponent<EnemyScript>().damage += 2;
        enemy.GetComponent<EnemyScript>().moveSpeed += 2;
    }
}


