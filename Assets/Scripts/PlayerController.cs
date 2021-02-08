using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    public Text countText; 
    public GameObject winTextGO; 

    private Rigidbody rb;
    private int count; 

    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        winTextGO.SetActive(false); 
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 v = movementValue.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText(); 
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 6)
        {
            // Set the text value of your 'winText'
            winTextGO.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
