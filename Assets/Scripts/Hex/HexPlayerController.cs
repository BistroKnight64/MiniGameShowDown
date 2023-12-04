using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float horizInput;
    public float vertInput;
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
        //Declarations
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizInput * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * vertInput * moveSpeed * Time.deltaTime);

        //Object Destroys itself after falling past a specific height.
        if (gameObject.transform.position.y <= deathHeight)
        {
            Debug.Log($"THE {gameObject.name} IS DEAD!!!");
            Destroy(gameObject);
        }

        //Object Jumps into the air if they are currently on the ground, and press a key.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
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
