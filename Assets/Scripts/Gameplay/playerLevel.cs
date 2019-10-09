using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLevel : MonoBehaviour
{
    public static int playerLvl;
    public int xpMod;
    public int xpRequired;
    public int xpCurrent; 

    // Start is called before the first frame update
    void Start()
    {
        playerLvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(xpCurrent >= xpRequired)
        {
            playerLvl++;
            xpCurrent -= xpRequired;
            xpRequired *= xpMod;
        }
    }
}
