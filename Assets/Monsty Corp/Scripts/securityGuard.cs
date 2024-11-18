using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using LevelManager;

public class securityGuard : MonoBehaviour
{

	public LevelManager levelManager;
  void OnTriggerEnter(Collider other)
  {
	  levelManager.playerDeath();
  }
}