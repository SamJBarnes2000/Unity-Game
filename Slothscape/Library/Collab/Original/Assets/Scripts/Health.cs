using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currhealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currhealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) ) //will be assigned to an enemies damage value but for the moment it triggers when space it hit
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer( int damage )
    {
        currhealth -= damage;

        healthBar.SetHealth( currhealth );
    }
}
