using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public SpawnManager _spawnManager;
    public PlayerMove _playerMove;
    public UnityEvent AsterScore;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpawnTrigger")
        {
            _spawnManager.SpawnTriggerEntered();
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
            _playerMove.enabled = false;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -1f, transform.position.z), Time.deltaTime * 10);
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}