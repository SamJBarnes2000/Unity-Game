using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool PlayerInRange;
    public bool isOpen;
    public GameObject[] objects;
    public Transform spawnPoint;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }
    void Update() {
       if (Input.GetKeyDown(KeyCode.E) && PlayerInRange)
       {
           if(!isOpen)
           {
               OpenChest();
               GetRandomItem();
           }
       }
   }

   public void OpenChest()
   {
       isOpen = true;
       anim.SetBool("Opened", true);

       GameObject item = Instantiate(objects[Random.Range(0, objects.Length)], spawnPoint.position, spawnPoint.rotation) as GameObject;
   }

   public void GetRandomItem()
   {
       //Database.GetRandomItem();
   }

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.CompareTag("Player"))
       {
           PlayerInRange = true;
       }    
   }

   private void OnTriggerExit2D(Collider2D other) {
       if(other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
   }
}
