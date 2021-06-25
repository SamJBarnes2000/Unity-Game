using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private EnemyHealthManager enemyHealthManager;
    
    [SerializeField]
    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {
       // enemyHealthManager = FindObjectOfType<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemyHealthManager.HurtEnemy(damageToGive);
    }

    public void ChangeDamage(int damageItemAmount)
    {
        damageToGive += damageItemAmount;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if ((other.tag == "Enemy") || (other.tag == "Boss")) 
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }


}
