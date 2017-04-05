using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Robot")
        {
            Debug.Log(collision.collider.GetComponent<Robot>().health);
            if (collision.collider.GetComponent<Robot>())
            {
                collision.collider.GetComponent<Robot>().healEffects();
            }
        }

    }


}
