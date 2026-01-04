using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction ;
    [SerializeField] private float moveSpeed;
    //Update is called once per frame
    void FixedUpdate() 
    {
        //face the player
        if (PlayerController.Instance.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        //move towards player
        direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        /*player location - enemy location calculation
        normalized:say fow without normalized if far the enemy the fast it move the close the enemy the slow it moves 
        with normaalized it moves at constant speed, which we controlled with the moveSpeed variable 
        */

        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        // this sets the new loaction for the bird
    }//due to fixed update it always keep on happening

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}


