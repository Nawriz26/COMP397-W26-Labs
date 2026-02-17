using UnityEngine;

public class Bullet : MonoBehaviour
{
     private void OnCollisionEnter(Collision other)
     {
        Debug.Log("Bullet collided with: " + other.gameObject.name, other.gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
