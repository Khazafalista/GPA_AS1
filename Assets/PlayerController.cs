using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject flashLight;
    public GameObject mainCamera;
    bool isLight;
    Animator playerAnimator;
    Vector3 startPos;
    Vector3 startForward;
    public Canvas menuCanvas;
    bool menuCovered;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isLight = true;
        playerAnimator = GetComponent<Animator>();
        startPos = rb.transform.position;
        startForward = rb.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        menuCovered = menuCanvas.enabled;
        if(!menuCovered) {
            if(Input.GetKeyDown(KeyCode.LeftControl)) {
                isLight = !isLight;
                flashLight.SetActive(isLight);
            }
            if(Input.GetKeyDown(KeyCode.R)) {
                rb.transform.position = startPos;
                rb.transform.rotation = Quaternion.LookRotation(startForward);
            }
        }
        
    }

    void FixedUpdate() {
        menuCovered = menuCanvas.enabled;
        if(!menuCovered) {
            float V = Input.GetAxis("Vertical");
            float H = Input.GetAxis("Horizontal");
            float mSpeed = 1.5f;
            float rSpeed = 2.0f;

            playerAnimator.SetFloat("Speed", V);

            rb.velocity = gameObject.transform.forward * mSpeed * V;

            gameObject.transform.Rotate(new Vector3(0, H * rSpeed, 0));
            if(Input.GetKey(KeyCode.Q)) {
                if(mainCamera.transform.eulerAngles.x < 30.0f || mainCamera.transform.eulerAngles.x > 180.0f) {
                   mainCamera.transform.Rotate(new Vector3(rSpeed, 0, 0)); 
                }
            }
            if(Input.GetKey(KeyCode.E)) {
                if(mainCamera.transform.eulerAngles.x > 350.0f || mainCamera.transform.eulerAngles.x < 180.0f) {
                   mainCamera.transform.Rotate(new Vector3(-rSpeed, 0, 0)); 
                }
            }
            rb.angularVelocity = Vector3.zero;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
       if(other.gameObject.tag == "Arrow") {
            Debug.Log("Collision!");
            rb.transform.position = startPos;
        }
    }
}
