using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Combat : MonoBehaviour
{
    private int atkDmg;
    private int damageRating;

    public int str;
    public int mag;
    private int def;
    private int HP;
    public int agi;
    public int lvl;

    private int targetStr;
    public int targetMag;
    public int targetDef;
    private int targetHP;
    public int targetAgi;
    public int targetLvl;

    private int turn;

    public bool magAtk;
    public bool backRow;
    public bool targetBackRow;
    public bool targetStunned;

    static Random rnd = new Random();
    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space was pressed");
            Debug.Log("--------New Damage Calculation!--------");
            DamageCalculator(str, mag, agi, lvl, 4, targetMag, targetDef, targetAgi, targetLvl);
        }
    }

    int DamageCalculator(int strValue, int magValue, int agiValue, int lvlValue, int targetValue, int targetMagValue, int targetDefValue, int targetAgiValue, int targetLvlValue)
    {
        int hitCritChance = rnd.Next(0, 200) + 1;
        if (!magAtk)
        {
            DamageRating();
            PhysAttackChance();
        }
        else
        {

        }

        void PhysAttackChance()
        {
            if (hitCritChance != 200 && hitCritChance <= agiValue * 2 && hitCritChance <= 100 - targetAgiValue / 2 || hitCritChance == 1)
            {
                Debug.Log("Crit!");
                int damage = rnd.Next(damageRating, (damageRating) * 2);
                Debug.Log("Pre-Crit Damage: " + damage);
                atkDmg = damage * 2;
            }
            else if (hitCritChance != 200 && hitCritChance <= 150 + (agiValue / 2) - (targetAgiValue / 4) || targetStunned == true)
            {
                Debug.Log("Hit!");
                Debug.Log("# Needed to Crit: " + (agiValue * 2));
                PhysicalAttack();
            }
            else
            {
                Debug.Log("Missed!");
                Debug.Log("# Needed to Hit: " + (150 + (agiValue / 2) - (targetAgiValue / 4)));
                atkDmg = 0;
            }
            Debug.Log("Hit Chance: " + hitCritChance);

        }

        void DamageRating()
        {
            if (!backRow)
            {
                damageRating = ((strValue / 2) * ((lvlValue + 1)/ 2));
            }
            else
            {
                Debug.Log("Damage reduced by half due to: Back Row");
                damageRating = ((strValue / 4) * ((lvlValue + 1) / 2));
            }
            Debug.Log("Attacker Damage Rating: " + damageRating);
        }

        void PhysicalAttack()
        {
            int damage = rnd.Next(damageRating, damageRating * 2);
            atkDmg = damage - targetDefValue;
            Debug.Log("Raw Damage: " + damage + " Reduced by: " + targetDefValue + " Target Defense!");
        }

        if (atkDmg < 1)
        {
            if (targetValue <= 3)
            {
                atkDmg = 0;
            } else if (targetValue > 3)
            {
                atkDmg = 1;
            }
        }
        else if (atkDmg > 9999)
        {
            atkDmg = 9999;
        }

        Debug.Log("Final Damage: " + atkDmg);
        return atkDmg;
    }
}