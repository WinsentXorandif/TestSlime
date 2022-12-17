using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    private const float DESTROY_TIME = 2f;
    private const float LIFE_TIME = 60f;

    private int attackDamage;
    private Rigidbody arrowbody;
    private Collider coll;
    private bool IsHIT;

    private void Awake()
    {
        coll = GetComponent<Collider>();
        arrowbody = GetComponent<Rigidbody>();
    }

    public void InitBall(int attack, float speed)
    {
        attackDamage = attack;
        arrowbody.velocity = transform.forward * speed;

        IsHIT = false;
        StartCoroutine(ArrowFly());
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsHIT = true;
        StopCoroutine(ArrowFly());

        if (collision.collider.TryGetComponent<EnemyUnitPlay>(out var enemy))
        {
            enemy.OnDamage(attackDamage);
        }

        this.gameObject.SetActive(false);

    }

    IEnumerator ArrowFly()
    {
        float lifeTimer = 0.0f;

        while (lifeTimer < LIFE_TIME)
        {
            if (!IsHIT)
            {
                transform.rotation = Quaternion.LookRotation(arrowbody.velocity, Vector3.up);
            }
            lifeTimer += Time.deltaTime;
            yield return null;
        }

        this.gameObject.SetActive(false);
    }
}
