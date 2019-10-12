using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);

        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
