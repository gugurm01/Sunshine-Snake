using UnityEngine;
using UnityEngine.Video;

public class EnemyBig : MonoBehaviour
{

    public float spd;
    private Transform target;

    [SerializeField] private int lives;
    
    Animator animator;
    public GameObject attack;
    //attack.SetActive(true);
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, spd * Time.deltaTime);

        if(spd == 0)
        {
            animator.SetBool("isRunning", false);
        }

        animator.SetBool("isRunning", true);

        if (transform.position.x < target.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    public void TakeDamage(int dano)
    {
        lives -= dano;

        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}