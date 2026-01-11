using UnityEngine;

public class ContactManager : MonoBehaviour
{
    private GameObject contact;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Untalkable")
            contact = other.gameObject; 
    }
    private void OnTriggerExit2D(Collider2D other) { 
        if (contact == other.gameObject)
            contact = null; 
    }
    public GameObject GetContact() { return contact; }
}
