using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerLogic : Hero
{
    [SerializeField]
    private float playerDamage = 2f;
    private Animator animator;
    private float attackRadius = 2f;
    private Vector3 centerOfAttack;
    private Hashtable inventory = new Hashtable();

    [SerializeField]
    private AudioSource attackSound;

    private void Start()
    {
        playerDamage = PlayerPrefs.GetFloat("Damage",playerDamage);
        animator = GetComponent<Animator>();
        EventManager.current.onUpDamage += UpDamage;
        EventManager.current.onTreeDestroy += Inventory;
    }

    private void Update()
    {
        centerOfAttack = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            animator.SetTrigger("Attack");
        }
    }

    protected override void AttackTypeLogic()
    {
        Collider[] hitColliders = Physics.OverlapSphere(centerOfAttack, attackRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Tree")
            {
                hitCollider.GetComponent<Tree>().HealthDecrease(playerDamage);
            }
        }
    }

    protected override void UpDamage()
    {
        playerDamage *=1.4f;
        PlayerPrefs.SetFloat("Damage", playerDamage);
    }

    protected override void Inventory(Treetypes type)
    {
        if (inventory.ContainsKey(type))
        {
            int a = (int)inventory[type];
            a++;
            inventory.Remove(type);
            inventory.Add(type,a);
        }
        else 
        {
            inventory.Add(type, 1);
        }
    }

    public Hashtable GetInventory()
    {
        return inventory;
    }

    private void AttackSound()
    {
        attackSound.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        attackSound.Play();
    }
}
