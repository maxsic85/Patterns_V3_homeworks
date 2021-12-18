using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerProvider : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        //private Camera _camera;
        public Ship _ship {get;set;}
        ShipView shipView;
        BarrelModel barrelModel;

        private void Start()
        {
            shipView = GetComponent<ShipView>();
            barrelModel = new BarrelModel(_barrel, 50, 10);
            //_camera = Camera.main;
        //    _ship = FindObjectOfType<Starter>().Ship;
            //var moveTransform = new AccelerationMove(transform, _ship._shipModel.Speed, _ship._shipModel.Accseleration);
            //var rotation = new RotationShip(transform);
        }
        private void Update()
        {
         //   shipView.UpdateUI(_ship);
            //var direction = Input.mousePosition -
            //_camera.WorldToScreenPoint(transform.position);
            //_ship.Rotation(direction);
            //_ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
            //Time.deltaTime);
            //if (Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //    _ship.AddAcceleration();
            //}
            //if (Input.GetKeyUp(KeyCode.LeftShift))
            //{
            //    _ship.RemoveAcceleration();
            //}
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Instantiate(_bullet, barrelModel.startPosition.position,
                _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * barrelModel.Force);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_ship.hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _ship.hp--;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_ship.hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _ship.hp--;
            }
        }

        private void OnBecameInvisible()
        {
            transform.position = Vector3.down;
        }
    }
}
