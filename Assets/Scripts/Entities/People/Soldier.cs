// using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Entities.People {
  public class Soldier : MonoBehaviour {
    private Rigidbody2D Rb;
    public Transform target;

    private Vector2 wanderDirection;
    private float wanderTimer;
    private float wanderChangeTime;

    public float wanderMoveSpeed = 2f;
    public float searchMoveSpeed = 3f;

    public float separationDistance = 2f;
    public float flockingForceStrength = 1f;

    private enum State { Wander, Searching, Fighting }
    private State state = State.Wander;
    private State nextState = State.Wander;
    public bool isAtWar = false;

    private void Start() {
      Rb = GetComponent<Rigidbody2D>();
    }

    private void StateMachine() {
      switch(state) {
        case State.Wander:
          Wander();
          break;

        case State.Searching:
          Search();
          break;

        case State.Fighting:
          Fight();
          break;
      }

      state = nextState;
    }

    // Time of peace
    private void Wander() {
      wanderTimer += Time.deltaTime;

      if(wanderTimer >= wanderChangeTime) {
        ChooseRandomWanderDirection();
      }

      Rb.velocity = wanderDirection * wanderMoveSpeed;

      // War started: Switch to search for enemies
      if(isAtWar) { nextState = State.Searching; }
    }

    private void ChooseRandomWanderDirection() {
      float angle = Random.Range(0f, Mathf.PI * 2f);

      wanderDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

      wanderChangeTime = Random.Range(2f, 5f);
      wanderTimer = 0f;
    }

    // Time of war with no enemies around
    private void Search() {
      List<Soldier> nearbySoldiers = FindNearbySoldiers();
      Vector2 flockingForce = CalculateFlockingForce(nearbySoldiers);
      // War ended: Switch to wander 
      if (!isAtWar) { nextState = State.Wander; }
    }

    // This function could be generalized to work with List<Entity> if flocking parameters are hoisted
    private Vector2 CalculateFlockingForce(List<Soldier> nerbySoldiers) {
      List<Soldier> nearbySoldiers = FindNearbySoldiers();
      Vector2 separationForce = Vector2.zero;
      Vector2 alignmentForce = Vector2.zero;
      Vector2 cohesionForce = Vector2.zero;

      if (nearbySoldiers.Count > 0) {
        Vector2 avgPosition = Vector2.zero;
        Vector2 avgDirection = Vector2.zero;

        foreach (Soldier soldier in nearbySoldiers) {
          Vector2 toSoldier = soldier.transform.position - transform.position;

          // Separation: Move away from soldiers that are too close
          if (toSoldier.magnitude < separationDistance) {
            separationForce -= toSoldier.normalized / toSoldier.magnitude;
          }

          avgPosition += (Vector2)soldier.transform.position;
          avgDirection += (Vector2)soldier.Rb.velocity;
        }

        // Cohesion: Move towards the center of the group
        avgPosition /= nearbySoldiers.Count;
        cohesionForce = (avgPosition - (Vector2)transform.position).normalized;

        // Alignment: Align velocity with the average direction of the group
        avgDirection /= nearbySoldiers.Count;
        alignmentForce = avgDirection.normalized;
      }

      // Combine the forces for flocking behavior
      return (separationForce + cohesionForce + alignmentForce) * flockingForceStrength;

    }

    private List<Soldier> FindNearbySoldiers() {
      List<Soldier> nearbySoldiers = new List<Soldier>();

      // Find all soldiers within a certain radius
      Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, separationDistance * 2);
      foreach (Collider2D hit in hits) {
        Soldier otherSoldier = hit.GetComponent<Soldier>();
        if (otherSoldier != null && otherSoldier != this) {
         
          // If the soldier sees a fellow soldier fighting, he will join the fight
          if(otherSoldier.state == State.Fighting) { 
            nextState = State.Fighting; 
          }

          nearbySoldiers.Add(otherSoldier);
        }
      }

      return nearbySoldiers;

    }

    // Time of war with enemies around
    private void Fight() {

      // War ended: Switch to wander
      if (!isAtWar) { nextState = State.Wander; }
    }

    private void Update() {
      StateMachine();
    }

    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(transform.position, separationDistance * 2);
    }

  }
}