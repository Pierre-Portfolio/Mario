using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHead : MonoBehaviour
{

    GoombaMove gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponentInParent<GoombaMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.KillGoomba();
        }
    }

}
