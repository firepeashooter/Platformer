using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private bool canJump;
    private bool canAttack;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private bool groundCheck;
    private float horizontalInput;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int speed;
    public int jumpHeight;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see that we can jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            canJump = true;

        }

        if (Input.GetKeyDown(KeyCode.E)){
            canAttack = true;
            animator.SetBool("Attack", true);
            
        }

        


        //Gets the horizontal input
        horizontalInput = Input.GetAxis("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
    }

    void FixedUpdate() {

        if (canAttack){
            animator.SetBool("Attack", false);
        }
        //Jump Code
        if (canJump){
            rigidbody2d.velocity = Vector2.up * jumpHeight;
            canJump = false;
        }

        //Horizontal movement code
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalInput, rigidbody2d.velocity.y);

        if (horizontalInput < 0){
            spriteRenderer.flipX = true;
        } else {
            spriteRenderer.flipX = false;
        }

        
    }
    

    private bool IsGrounded(){
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }
}
