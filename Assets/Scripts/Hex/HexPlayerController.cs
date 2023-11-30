using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPlayerController : MonoBehaviour
{
    public float horizInput;
    public float vertInput;
    public float moveSpeed;
    public float jumpForce;

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
    }
}
