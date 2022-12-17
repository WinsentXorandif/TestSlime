using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMagic : HeroUnitPlay
{
    private const float MAX_ANGLE_DEGREES = 40f;
    private const int PROJECTILE_COUNT = 3;

    [SerializeField]
    private Transform arrowStartPoint;

    private ObjectsPool<MagicBall> projectilePool;
    private float g = Physics.gravity.y;
    private float AngleInDegrees;


    private void Start()
    {
        projectilePool = new ObjectsPool<MagicBall>(projectile, transform, PROJECTILE_COUNT);
    }

    public void Shoot()
    {

        Vector3 enemyTarget = enemyCol.transform.position;
        enemyTarget.y -= 0.5f;

        Vector3 fromTo = enemyTarget - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        MagicBall mb = projectilePool.GetFreeElement();
        mb.transform.position = arrowStartPoint.position;
        mb.transform.rotation = arrowStartPoint.rotation;
        mb.InitBall(attack, v);

    }


    protected override void OnAttack()
    {
        if (enemyCol != null)
        {
            Shoot();
        }
    }

    void Update()
    {
        OnUpdate();

    }
}
