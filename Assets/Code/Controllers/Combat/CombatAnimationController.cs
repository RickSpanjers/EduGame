using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAnimationController : MonoBehaviour
{
    public Animator animatorCharacter;
    public Animator animatorEnemy;
    public AudioSource victoryFanfare;

    public void AttackPlayerAnimation()
    {
        animatorCharacter.SetBool("Attack", true);
        animatorEnemy.SetBool("Hurt", true);
    }

    public void AttackEnemyAnimation()
    {
        animatorEnemy.SetBool("Attack", true);
        animatorCharacter.SetBool("Hurt", true);
    }

    public void OnFinishedAttackAnimation()
    {
        if (animatorCharacter.GetCurrentAnimatorStateInfo(0).IsName("KnightAttack"))
        {
            animatorCharacter.SetBool("Attack", false);
        }
        if (animatorEnemy.GetCurrentAnimatorStateInfo(0).IsName("DragonAttack"))
        {
            animatorEnemy.SetBool("Attack", false);
        }
    }

    public void OnFinishedDamageAnimation()
    {
        if (animatorEnemy.GetCurrentAnimatorStateInfo(0).IsName("DragonHurt"))
        {
            animatorEnemy.SetBool("Hurt", false);
        }
        if (animatorCharacter.GetCurrentAnimatorStateInfo(0).IsName("KnightHurt"))
        {
            animatorCharacter.SetBool("Hurt", false);
        }
    }

    public void BattleConclusionAnimation(bool victory)
    {
        if (victory)
        {
            victoryFanfare.Play();
            animatorEnemy.SetBool("Death", true);
        }
        else
        {
            animatorCharacter.SetBool("Death", true);
        }
    }

    public Animator getAnimatorCharacter()
    {
        return animatorCharacter;
    }

    public Animator getAnimatorEnemy()
    {
        return animatorEnemy;
    }

    public AudioSource getVictoryFanfare()
    {
        return victoryFanfare;
    }
}
