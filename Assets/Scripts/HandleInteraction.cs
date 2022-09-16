using UnityEngine;

public class HandleInteraction : MonoBehaviour
{
    PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Interactable")
        {
            player.InteractionAvailable = true;
            Interactable obj= collision.GetComponent<Interactable>();
            player.InteractableThing = obj;
        }      
    }
}
