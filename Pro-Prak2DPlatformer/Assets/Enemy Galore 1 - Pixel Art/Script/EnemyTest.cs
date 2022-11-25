using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] private Animator[] EnemyAnims;

    public void Animation_1_Idle()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is Idling");
            }
        }
    }
    public void Animation_2_Run()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", true);
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is Running");

            }
        }
    }
    public void Animation_3_Hit()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetTrigger("Hit");
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is being Hit");
            }
        }
    }
    public void Animation_4_Death()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetTrigger("Death");
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " has died");
            }
        }
    }
    public void Animation_5_Ability()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetBool("Ability", true);
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is using its First Ability");
            }
        }
    }
    public void Animation_5_Ability2()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetBool("Ability 2", true);
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is using its Second Ability");
            }
        }
    }
    public void Animation_5_Ability3()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetBool("Ability 3", true);
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is using its Third Ability");
            }
        }
    }
    public void Animation_6_Attack()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetTrigger("Attack");
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is using using its Primary Attack");
            }
        }
    }

    public void Animation_7_Attack2()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetTrigger("Attack 2");
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is using using its Secondary Attack");
            }
        }
    }
    public void Animation_8_Attack3()
    {
        for (int i = 0; i < EnemyAnims.Length; i++)
        {
            if (EnemyAnims[i].gameObject.activeSelf == true)
            {
                EnemyAnims[i].SetBool("Run", false);
                EnemyAnims[i].SetTrigger("Attack 3");
                Debug.Log("The enemy " + EnemyAnims[i].gameObject.name + " is using using its Tertiary Attack");
            }
        }
    }
}
