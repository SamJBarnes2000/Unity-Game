using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private Health healthman;
    public float waitTohurt = 2f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10; //can change damage in inspector for each emeny type

    // Start is called before the first frame update
    void Start()
    {
        healthman = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            waitTohurt -= Time.deltaTime;
            if (waitTohurt <= 0)
            {
               healthman.DamagePlayer(damageToGive);
               waitTohurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().DamagePlayer(damageToGive);
        }

    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
       
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitTohurt = 2f;
        }
    }
}
