using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HexPlayerController : MonoBehaviour
{
    [Header("Movement")]
    public Vector2 moveInput;
    public float moveSpeed;
    public float jumpForce;
    public bool isOnGround;
    public int deathHeight;

    [Header("Components")]
    public Rigidbody rb;
    public BoxCollider bx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(moveInput * moveSpeed * Time.deltaTime);

        //Object Destroys itself after falling past a specific height.
        if (gameObject.transform.position.y <= deathHeight)
        {
            Destroy(gameObject);
        }
   
    }

    public void Moving(InputAction.CallbackContext context)
    {
        //Declarations
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput.ToString());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(isOnGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
     
    }

    public void Shove()
    {

    }

    //Lets the object know when its returned to the ground.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
