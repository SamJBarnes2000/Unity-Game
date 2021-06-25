using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameOver gameOver;
    public Text TextCurrHealth;
    public Text TextMaxHealth;
    [SerializeField]
    public int currhealth = 0;
    public int maxHealth = 100;
    public HealthBar healthBar;

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        currhealth = maxHealth;
        TextCurrHealth.text = currhealth.ToString();
        TextMaxHealth.text = maxHealth.ToString();

    }

    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength *.99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            } 
            else if (flashCounter > flashLength *.82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength *.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength *.49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength *.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength *.16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0F)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }


    }

    public void DamagePlayer( int damage )
    {
        currhealth -= damage;
        flashActive = true;
        flashCounter = flashLength;

        if (currhealth <= 0)
        {
            gameObject.SetActive(false);
            GameOverScreen();
        }

        updateHealthbar();
    }

    public void HealPlayer(int healthItemAmount)
    {
        currhealth += healthItemAmount;
        if (currhealth > maxHealth)
        {
            currhealth = maxHealth;
        }

        updateHealthbar();
    }

    public void ChangeMaxHealth(int addTOHealth)
    {
        maxHealth += addTOHealth;

        updateHealthbar();
    }

    public void updateHealthbar()
    {
        healthBar.SetHealth( currhealth );
        healthBar.SetMaxHealth(maxHealth);
        TextCurrHealth.text = currhealth.ToString();
        TextMaxHealth.text = maxHealth.ToString();
    }

    public void GameOverScreen() 
    {
        gameOver.Setup();
    }
}
