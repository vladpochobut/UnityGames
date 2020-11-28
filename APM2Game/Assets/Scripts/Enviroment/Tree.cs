using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private float treeHP = 4f;
    private float fullHp;

    [SerializeField]
    private GameObject oldTree;

    [SerializeField]
    private GameObject hulfHpTree;

    [SerializeField]
    private GameObject lowHpTree;

    private Object explosion;
    private GameObject explosionRef;

    [SerializeField]
    private Treetypes type;

    private void Start()
    {
        fullHp = treeHP;
        explosion = Resources.Load("CutExplosion");
        oldTree.SetActive(true);
        hulfHpTree.SetActive(false);
        lowHpTree.SetActive(false);

    }

    private void Update()
    {
        TreeDestroyer();    
    }

    private void TreeDestroyer()
    {
        if (treeHP <= (fullHp / 2) && treeHP > (fullHp / 4))
        {
            oldTree.SetActive(false);
            hulfHpTree.SetActive(true);
        }
        else if (treeHP <= (fullHp / 4) && treeHP > 0)
        {
            hulfHpTree.SetActive(false);
            lowHpTree.SetActive(true);
        }
        else if (treeHP <= 0)
        {
            gameObject.SetActive(false);
            EventManager.current.TreeDestroy(type);
            Destroy(gameObject);
        }
    }
    public void HealthDecrease(float damage)
    {
        explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Invoke("ExplosionDestroyer", 1);
        treeHP -= damage;
    }

    private void ExplosionDestroyer()
    {
        if (explosionRef != null)
        {
            Destroy(explosionRef);
        }
    }

}
