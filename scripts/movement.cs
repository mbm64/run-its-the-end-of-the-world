using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D player;
    public float runSpeed = 5;
    private float curSpeed;
    public int orientation = 1;
    public float wallBounce = 0.01f;
    public float groundDist = 0.01f;
    public GameObject sense;
    public GameObject groundSense;
    public LayerMask wall;
    public LayerMask water;
    public float jumpForce = 5;
    public float fallScale = 2.5f;
    private Collider2D coll;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        curSpeed = runSpeed;
        player = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouchingWater())
        {
            curSpeed = runSpeed * 0.5f;
            if (player.velocity.y < 0) player.drag = 3;
            else player.drag = 0;
        }
        
        else
        {
            curSpeed = runSpeed;
            player.drag = 0;
        }
        Vector2 currentVel = player.velocity;
        currentVel.x = curSpeed * orientation;
        if (player.velocity.y < 0 && !isTouchingWater())
        {
            player.gravityScale = fallScale;
        }
        else player.gravityScale = 1;
        player.velocity = currentVel;
        
        if(isTouchingWall())
        {
            orientation *= -1;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        if(player.velocity.x == 0)
        {
            Debug.Log("stuck");
        }
        
        if(Input.GetKeyDown("space") && (isGrounded()||isTouchingWater()))
        {
            Vector2 speed = player.velocity;
            speed.y = 0;
            player.velocity = speed;
            player.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            
        }
        if (isGrounded())
        {
            anim.SetBool("inAir", false);
        }
        else
        {
            anim.SetBool("inAir", true);
        }
        anim.SetFloat("yVel", player.velocity.y);
    }
    bool isGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(groundSense.transform.position, new Vector2(0.9f, groundDist * 2), 0, Vector2.down, 0, wall);
        if(hit.collider != null  )
        {
            return true;
        }
        return false;
    }
    bool isTouchingWall() {
        RaycastHit2D hit = Physics2D.BoxCast(sense.transform.position, new Vector2(wallBounce * 2, 1.9f), 0, new Vector2(orientation, 0), 0, wall);
        if (hit.collider != null && hit.collider.tag != "Clear")
        {
            return true;
        }
        return false;
    }
    bool isTouchingWater()
    {
        RaycastHit2D hit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.zero, 0, water);
        if(hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
