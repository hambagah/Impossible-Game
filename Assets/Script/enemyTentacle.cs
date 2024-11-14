using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTentacle : MonoBehaviour
{
    [SerializeField] private Transform tentacleLocation;
    public float tShootTime = 3f;
    public float tDelay = 0;
    public float eBulletSpeed = 4f;
    public eBullet ebullet;
    Player target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tDelay > tShootTime)
        {    
            Attack();
            tDelay = Random.Range(0f, 1f);
        }
        else
            tDelay += Time.deltaTime;
    }

    private void Attack()
    {
        Vector3 bulVector = new Vector3(target.transform.position.x, target.transform.position.y, 0f);
        Vector2 bulDir = (bulVector - tentacleLocation.position).normalized;
        eBullet bul = Instantiate(ebullet, tentacleLocation.position, transform.rotation);
        bul.GetComponent<eBullet>().SetMoveDirection(bulDir);
        bul.GetComponent<eBullet>().SetSpeed(eBulletSpeed);
    }
}
