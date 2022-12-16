using UnityEngine;

[CreateAssetMenu(fileName = "NewUnitData", menuName = "New Unit Data")]
public class UnitData : ScriptableObject
{
    [SerializeField]
    private int unitHitPoint;
    [SerializeField]
    private int unitDefence;
    [SerializeField]
    private int unitAttack;
    [SerializeField]
    private float unitMoveSpeed;
    [SerializeField]
    private LayerMask enemyLayer;
    [SerializeField]
    private GameObject projectile;



    public int GetHitPoint()
    {
        return unitHitPoint;
    }
    public int GetDefence()
    {
        return unitDefence;
    }
    public int GetAttack()
    {
        return unitAttack;
    }
    public float GetMoveSpeed()
    {
        return unitMoveSpeed;
    }
    public LayerMask GetEnemyLayer()
    {
        return enemyLayer;
    }
    public GameObject GetProjectile()
    {
        return projectile;
    }

}
