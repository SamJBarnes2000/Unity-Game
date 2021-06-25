using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public List<string> items;
    public int speedItemAmount = 1000;
    public int healthItemAmount = 20;
    public int resistanceItemAmount = 10;
    public int damageItemAmount = 20;
    private Rigidbody2D myRB;
    private Animator myAnim;
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool IsAttacking;

    private Health health;

    [SerializeField]
    private float speed = 300;

    [SerializeField]
    private float sprintSpeed = 400;

    [Header ("Health Items")]
    //Health Item Dialouge
    public GameObject dialogueBoxHealth;
    public Text dialogueTextHealth;
    public string dialogueHealth;

    [Header ("Damage Items")]
    //Damage Item Dailouge
    public GameObject dialogueBoxDamage;
    public Text dialogueTextDamage;
    public string dialogueDamage;
    
    [Header ("Resistance Items")]
    //Resistance Item Dialouge
    public GameObject dialogueBoxResistance;
    public Text dialogueTextResistance;
    public string dialogueResistance;

    [Header ("Speed Items")]
    //Speed Item Dailouge
    public GameObject dialogueBoxSpeed;
    public Text dialogueTextSpeed;
    public string dialogueSpeed;

    public float waitfortext;
    public Transform keyFollowPoint;
    public Key followingKey;
    public bool itempickup;





    // Start is called before the first frame update
    void Start()
    {
        items = new List<string>();
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        dialogueBoxDamage.SetActive(false);
        dialogueBoxSpeed.SetActive(false);
        dialogueBoxResistance.SetActive(false);
        dialogueBoxHealth.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {

            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * sprintSpeed * Time.deltaTime;
        }
        else
        {
            myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        }

        if (IsAttacking)
        {
            myRB.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("IsAttacking", false);
                IsAttacking = false;
            }
        }

        if ((Input.GetKeyDown(KeyCode.Mouse0)) || (Input.GetKeyDown(KeyCode.Space)))
        {
            attackCounter = attackTime;
            myAnim.SetBool("IsAttacking", true);
            IsAttacking = true;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Damage Item
        if(collision.CompareTag("Damage-Item"))
        {
            //Change Text
            //Turn off the dialogue box if it's already active.
            dialogueBoxDamage.SetActive(true);
            dialogueTextDamage.text = dialogueDamage;       
            StartCoroutine(SetDamageFalse());
            

            //Increase Item
            HurtEnemy hurtEnemy;
            hurtEnemy = gameObject.GetComponent<HurtEnemy>();
            hurtEnemy.ChangeDamage(damageItemAmount);
            Destroy(collision.gameObject);
        }

        //Speed Item
        if(collision.CompareTag("Speed-Item"))
        {
            //Change Text
            //Turn off the dialogue box if it's already active.
            dialogueBoxSpeed.SetActive(true);               
            dialogueTextSpeed.text = dialogueSpeed;
            StartCoroutine(SetSpeedFalse());
                
            //Increase Item
            speed = speed + speedItemAmount;
            sprintSpeed = sprintSpeed + 20;
            Destroy(collision.gameObject);
        }

        //Resistance Item
        if(collision.CompareTag("Resistance-Item"))
        {
            //Change Text
            //Turn off the dialogue box if it's already active.
            dialogueBoxResistance.SetActive(true);               
            dialogueTextResistance.text = dialogueResistance;
            StartCoroutine(SetResistanceFalse());
                
            //Increase Item
            Health health;
            health = gameObject.GetComponent<Health>();
            health.ChangeMaxHealth(resistanceItemAmount);
            Destroy(collision.gameObject);
        }

        //Health Item
        if(collision.CompareTag("Health-Item"))
        {
            //Change Text
            //Turn off the dialogue box if it's already active.
            dialogueBoxHealth.SetActive(true);               
            dialogueTextHealth.text = dialogueHealth;
            StartCoroutine(SetHealthFalse());
                
            //Increase Item
            Health health;
            health = gameObject.GetComponent<Health>();
            health.HealPlayer(healthItemAmount);
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator SetDamageFalse()
    {
        yield return new WaitForSeconds(3f);
        dialogueBoxDamage.SetActive(false); 
    }

        public IEnumerator SetResistanceFalse()
    {
        yield return new WaitForSeconds(3f);
        dialogueBoxResistance.SetActive(false); 
    }

        public IEnumerator SetSpeedFalse()
    {
        yield return new WaitForSeconds(3f);
        dialogueBoxSpeed.SetActive(false); 
    }

        public IEnumerator SetHealthFalse()
    {
        yield return new WaitForSeconds(3f);
        dialogueBoxHealth.SetActive(false); 
    }


}
