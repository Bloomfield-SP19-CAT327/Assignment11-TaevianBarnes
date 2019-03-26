using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyBullet : NetworkBehaviour
{

    [SyncVar]
    public Color color;

    public GameObject bulletPrefab;
    private float spawnBulletTime = 0;

    private float countdown = 3f;

    public override void OnStartClient()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
      
    void FixedUpdate()
    {
        if (isServer)
        {
            if (Time.deltaTime > spawnBulletTime)
            {
                CmdFireBullet();
            }
        }
    }

    [Command]
    public void CmdFireBullet()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, this.transform.position + (this.transform.forward * -1), Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (Vector3.forward * -1) * 17.5f;
        bullet.GetComponent<Bullet>().color = color;
        bullet.GetComponent<Bullet>().parentNetId = this.netId;
        spawnBulletTime = Time.deltaTime + Random.Range(3, 8);
        Destroy(bullet, -0.775f);
        spawnBulletTime = 0;
    }

}
