using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public GameObject rock;
    Animation rockFallAnimation;
    // Start is called before the first frame update
    void Start()
    {
        if(rock != null) {
            rockFallAnimation = rock.GetComponent<Animation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player") {
            if(rockFallAnimation != null) {
                rockFallAnimation.Play("RockFallAnimation");
            }
        }
    }
}
