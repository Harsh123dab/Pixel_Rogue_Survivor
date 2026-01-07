using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Animator animator;



    [SerializeField] float moveSpeed;
    public Vector3 playerMoverDirections;    // Update is called once per frame
    public float playerMaxHealth;
    public float playerHealth;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

     void Start()
    {
        playerHealth = playerMaxHealth;
        UIController.Instance.UpdateHealthSlider();
    }
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal"); //raw bcz to get input in whole number like -1(left) ,1(right) & 0(nothing) no decimals 
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoverDirections = new Vector3(inputX, inputY).normalized;//normalized makes the speed equal for diagonal movement

        animator.SetFloat("moveX", inputX);//connecting input one and the move one 
        animator.SetFloat("moveY", inputY);

        if (playerMoverDirections == Vector3.zero)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetBool("moving", true);
        }

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerMoverDirections.x * moveSpeed, playerMoverDirections.y * moveSpeed);
    }
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        UIController.Instance.UpdateHealthSlider();
        if (playerHealth <= 0)
        {
            gameObject.SetActive(false);    
        }
    }

}

   

    


