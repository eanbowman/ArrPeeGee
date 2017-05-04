using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        Debug.Log("Sword attack!");
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        Debug.Log("Sword Special attack!");
        animator.SetTrigger("Special_Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.name);
        if(other.tag == "Enemy")
        {
            other.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }
}
