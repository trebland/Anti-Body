using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 7f;

    public GameObject healthText;
    public Text sometext;

	[HideInInspector]
	public float speed;

    private int whoKilledMe;

	public float startHealth = 100;
	private float health;

	private bool isDead = false;

	void Start ()
	{
		speed = startSpeed;
		health = startHealth * ScoreScript.enemyHealthMultiplier;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;


		if (health <= 0 && !isDead)
		{
            whoKilledMe = 1;
            ScoreScript.scoreValue += 5;
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile") TakeDamage(100);
    }

    private void OnDestroy()
    {
        WaveSpawner.EnemiesAlive--;
        if (whoKilledMe == 0)
        {
            MenuScript.instance().playerHealth--;
            healthText.GetComponent<Text>().text = "Health: " + MenuScript.instance().playerHealth;
        }
    }

}