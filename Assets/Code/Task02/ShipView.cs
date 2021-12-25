using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids
{
  
    public class ShipView : MonoBehaviour
    {
        public Text _currentHP;
        public Text _currentSpeed;
        private Rigidbody2D rigidbody2D;
        private PlayerProvider player;

        public Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }

        private void Start()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            player = FindObjectOfType<PlayerProvider>();
            _currentSpeed = FindObjectOfType<Canvas>().transform.GetChild(0).transform.GetComponent<Text>();
            _currentHP = FindObjectOfType<Canvas>().transform.GetChild(1).transform.GetComponent<Text>();

        }

        public  void UpdateUI(Ship ship)
        {
            _currentHP.text =$"HP = {ship.hp.ToString()}";
            _currentSpeed.text = $"SPEED = {ship.speed.ToString()}";
        }
    }
}
