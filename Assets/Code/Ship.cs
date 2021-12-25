using UnityEngine;
namespace Asteroids
{
    public sealed class Ship 
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        public readonly ShipModel _shipModel;
        public readonly ShipView _shipView;
        public float speed;
        public float acceleration;
        public float hp;
        public EnemyProvider CurrentEnemy { get; set; }

        public float Speed => _moveImplementation.Speed;
        public Ship(ShipModel shipModel,ShipView shipView,IMove moveImplementation, IRotation rotationImplementation)
        {
            _shipModel = shipModel;
            _shipView = shipView;
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;

            speed = shipModel.Speed;
            acceleration = shipModel.Accseleration;
            hp = shipModel.HP;
           
        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }
        public void AddAcceleration()
        {
            if (_moveImplementation is IAcceleration accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        public void RemoveAcceleration()
        {
            if (_moveImplementation is IAcceleration accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}