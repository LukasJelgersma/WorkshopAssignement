using UnityEngine;

//little bitch movement script
public class EnemyMovement : MonoBehaviour
{//idle, attack
    private GameObject player;
    [SerializeField] private GameObject thisEnemy;
    [SerializeField] private Rigidbody rigidbody;
    private float speed = 0.05f;
    private const int ATTACK = 0;
    private const int IDLE = 1;
    private int state = ATTACK;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        rigidbody.MovePosition(transform.position + (player.transform.position - transform.position).normalized * speed);
    }
    
}
