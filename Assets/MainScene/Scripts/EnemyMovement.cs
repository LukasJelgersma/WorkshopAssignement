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
    private bool changedState = true;
    private int state = IDLE;
    private int number;

    private const int NORTH = 0;
    private const int WEST = 1;
    private const int SOUTH = 2;
    private const int EAST = 3;
    private int direction;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        if (state == ATTACK)
        {
            AttackPlayer();
        }

        if (state == IDLE)
        {
            if (changedState)
            {
                ChooseDirection();
                changedState = false;
            }
            WalkAround();
        }
    }

    private void AttackPlayer()
    {
        transform.LookAt(player.transform.position);
        rigidbody.MovePosition(transform.position +
                               (player.transform.position - transform.position).normalized * speed);
    }

    private void WalkAround()
    {
        rigidbody.MovePosition(rigidbody.position + transform.forward * speed);
        
        if (number == 1)
        {
            rigidbody.MovePosition(rigidbody.position + transform.right * speed);
        }
        else if (number == 2)
        {
            rigidbody.MovePosition(rigidbody.position + -transform.right * speed);
        }
            
        else if (number == 3)
        {
            rigidbody.MovePosition(rigidbody.position + transform.forward * speed);
        }
        else if (number == 4)
        {
            rigidbody.MovePosition(rigidbody.position + -transform.forward * speed);
        }
        
    }

    public void ChooseDirection()
    {
        number = Random.Range(1, 4);
        
        Debug.Log(number);

    }
    
    
    
}
