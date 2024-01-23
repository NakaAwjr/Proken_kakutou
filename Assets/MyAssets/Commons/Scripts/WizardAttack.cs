using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WizardAttack : CommonAttack
{
    Vector3 bulletPoint;
    [SerializeField] private GameObject BulletObj;

    protected override void Start()
    {
        base.Start();
        bulletPoint = transform.Find("BulletPoint").localPosition;
    }
    public override void Attack1()
    {
        float Direction = transform.localScale.x;

            GameObject bullet = Instantiate(BulletObj, transform.position + new Vector3(bulletPoint.x * Direction, bulletPoint.y, bulletPoint.z), Quaternion.identity);

            bullet.GetComponent<Bullet>().SetDirection(Direction);

            Destroy(bullet, 1.0f);
            _playerController._animator.SetTrigger("attack");
    }
}
