using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public RoadSpawnManager SpawnManager;
    public PlayerMove PlayerMove;
    public UnityEvent AsterScore;
    public UnityEvent EndGame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnTrigger")
        {
            SpawnManager.SpawnTriggerEntered();
        }
        if (other.tag == "Asteroid")
        {
            AsterScore.Invoke();
        }
        
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.collider.tag == "Asteroid")
        {
            PlayerMove.enabled = false;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -1f, transform.position.z), Time.deltaTime * 10);
            EndGame.Invoke();
        }
    }
}