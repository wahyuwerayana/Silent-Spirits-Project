using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    
    private GameObject currentTeleporter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentTeleporter != null)
            {
                Teleporter teleporter = currentTeleporter.GetComponent<Teleporter>();
                if (teleporter != null)
                {
                    transform.position = new Vector2(teleporter.GetDestination().position.x, teleporter.GetDestination().position.y - 1f);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                Teleporter2 teleporter = currentTeleporter.GetComponent<Teleporter2>();
                if (teleporter != null)
                {
                    transform.position = new Vector2(teleporter.GetDestination().position.x, teleporter.GetDestination().position.y - 1f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
        // else if (collision.CompareTag("Teleporter2"))
        // {
        //     currentTeleporter = collision.gameObject;
        // }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTeleporter)
        {
            currentTeleporter = null;
        }
    }
}
