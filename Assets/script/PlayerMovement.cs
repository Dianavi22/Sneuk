using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]

    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
  
    private bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;
    private float verticalMouvement;

    private float horizontalMovement;

    public static PlayerMovement instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;


    }
    void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMouvement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded && !isClimbing)
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("A") && isGrounded && !isClimbing)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
    }


    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        MovePlayer(horizontalMovement, verticalMouvement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {

        //Verification si le compte à rebour est toujours en cours
        if (Global.GlobalVariables.isMoving == true)
        {


            // Le jeu a commencé et le personnage peut commencer à bouger
            if (!isClimbing)
            {
                //Déplacement horizontal

                Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

                if (isJumping == true)
                {
                    rb.AddForce(new Vector2(0f, jumpForce));
                    isJumping = false;
                }
            }
            else
            {
                //Déplacement vertical

                Vector3 targetVelocity = new Vector2(0, _verticalMovement);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
            }
        }
        else
        {
            return;
        }



    }

        void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;

        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }


    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }


}
