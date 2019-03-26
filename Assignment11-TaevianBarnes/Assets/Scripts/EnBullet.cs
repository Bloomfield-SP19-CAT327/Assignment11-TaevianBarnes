using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class EnBullet : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
