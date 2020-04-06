using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Deathfx;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int healthPoints = 5;
    //[SerializeField] int healthPointsPerHit = 5;
    [SerializeField] int Hits = 5;

    ScoreBoard scoreBoard;
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        //adding a box collider to the enemy during run time.
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (Hits <= 0)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        // Same as below  ---->  Hits = Hits - 1;
        Hits--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(Deathfx, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        print("Particles colided with and destroyed " + gameObject.name);
        Destroy(gameObject);
    }
}
