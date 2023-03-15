using UnityEngine;
    
public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private HouseFade houseFade;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            houseFade.PlayerEntered();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            houseFade.PlayerExited();
        }
    }
}
