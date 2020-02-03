using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject arrow;
    public GameObject shooter;
    GameObject prefab;
    bool shoot = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        Rigidbody prefabRB;
        if(other.gameObject.name == "Player" && shoot) {
            prefab = Instantiate(arrow, shooter.GetComponent<Transform>().position, Quaternion.Euler(180.0f, 0.0f, 90.0f));
            prefabRB = prefab.GetComponent<Rigidbody>();
            prefabRB.velocity = prefabRB.transform.up * 5;
            prefabRB.angularVelocity = Vector3.zero;
            //shoot = false;
        }
    }
}
