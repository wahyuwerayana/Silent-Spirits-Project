using UnityEngine;

public class GroundFall : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(this.enabled == true){
            if (collision.gameObject.CompareTag("Player"))
            {
                rb.isKinematic = false; 
                rb.mass = 100;
            }
        }
    }
}
