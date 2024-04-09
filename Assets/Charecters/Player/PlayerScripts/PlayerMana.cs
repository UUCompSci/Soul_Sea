using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] public Image manaBar;
    [SerializeField] public int maxMana;
    [SerializeField] public int mana;
    [SerializeField] public float manaRegenSpeed;


    void Start()
    {
        mana = maxMana;
        //StartCoroutine(refillMana());
    }

    // Update is called once per frame
    void Update()
    {
        manaBar.fillAmount = mana / maxMana;
        Debug.Log(" mana fill amount: " + mana / maxMana);
    }

    IEnumerator refillMana()
    {
        while (true)
        {
            if (mana < maxMana)
            {
                mana++;
            }

            yield return new WaitForSeconds(manaRegenSpeed);
        }
    }

    public bool useMana(int manaUsed)
    {
        if(manaUsed > mana)
        {
            return false;
        }else if(manaUsed <= mana)
        {
            mana = mana - manaUsed;
            return true;
        }
        return false;
    }

    public void refillMana(int amountRefilled)
    {
        mana = mana + amountRefilled;
    }

    public void fullManaRefill()
    {
        mana = maxMana;
    }
}
