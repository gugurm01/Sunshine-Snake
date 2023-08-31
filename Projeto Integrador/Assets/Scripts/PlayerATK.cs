using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATK : MonoBehaviour
{
    private BoxCollider2D colliderAtkPlayer;

    [SerializeField] private Transform atkPoint;

    [SerializeField] private Transform Enemy;


    void Start()
    {
        colliderAtkPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
