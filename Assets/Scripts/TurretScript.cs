using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour {

    public GameObject whiteCell;
    //public BoxCollider2D range;

    private List<GameObject> enemyList;
    public int force;

    public float timer;

    private void Awake()
    {
        force = 300;
        enemyList = new List<GameObject>();
    }

    private void Update()
    {
        if (enemyList[0] != null)
        {
            GameObject target = enemyList[0];
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Fire();
                timer = 1f;
            }
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Fire();
            timer = 1f;
        }
    }

    private void Fire()
    {
        GameObject shot = Instantiate(whiteCell, transform.position, Quaternion.identity);
        shot.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyList.Add(collision.gameObject);
        }
    }

    private void UpdateList()
    {

    }

}
