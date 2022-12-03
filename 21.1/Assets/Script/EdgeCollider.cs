
using UnityEngine;

public class EdgeCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            //gameOver
            FindObjectOfType<GameController>().GameOver();
            Debug.Log("GameOver");
        }
        else if (collision.tag == "Cube")
        {
            //destroy go
            Destroy(collision.gameObject);
        }

    }
}
