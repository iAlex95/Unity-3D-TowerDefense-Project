﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
	private Transform target;
	private int waypointIndex = 0;

	private Enemy enemy;

	void Start() {
		enemy = GetComponent<Enemy>();
		target = Waypoints.points[0];
	}
	
	void Update() {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
	
		if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
			GetNextWaypoint();
		}

		enemy.speed = enemy.startSpeed;
	}

	private void GetNextWaypoint() {
		if (waypointIndex >= Waypoints.points.Length - 1) {
			EndPath();
			return;
		}
		waypointIndex++;
		target = Waypoints.points[waypointIndex];
	}

	private void EndPath() {
		Destroy(this.gameObject);
		PlayerStats.lives--;
	}
}
