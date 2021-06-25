using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider bosshealthBar;
    public EnemyHealthManager bossHealth;

    // Start is called before the first frame update
    private void Start()
    {
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<EnemyHealthManager>();
        bosshealthBar = GetComponent<Slider>();
        bosshealthBar.maxValue = bossHealth.maxHealth;
        bosshealthBar.value = bossHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        bosshealthBar.value = hp;
    }

}
