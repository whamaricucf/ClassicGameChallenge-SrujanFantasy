using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    public BattleStateMachine battleStateMachine;
    public TMP_Text damageDealt;
    public string damageText;
    
    public int PopUp(int damage)
    {
        damageText = damage.ToString();
        damageDealt.text = damageText;
        return damage;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
