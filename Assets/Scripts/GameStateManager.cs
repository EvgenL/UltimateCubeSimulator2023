using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStateManager : MonoBehaviour
    {
        private static GameStateManager _instance;
        // Singleton pattern
        public static GameStateManager Instance => _instance;

        private bool _isDead = false;
        private GameObject _player;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(_instance.gameObject);
                return;
            }
            
            _instance = this;
        }

        private void Start()
        {
            _player = FindObjectOfType<PlayerKeyboardInput>().gameObject;
        }

        public void Die()
        {
            Destroy(_player);
            _isDead = true;
        }
    }
}