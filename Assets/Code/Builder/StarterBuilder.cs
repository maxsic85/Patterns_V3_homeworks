using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MSuhinin.Builder
{
    public class StarterBuilder : MonoBehaviour
    {
       public AudioClip audioClip;

        // Start is called before the first frame update
        void Start()
        {
            var newGameObject = new  ShipBuilder();
            GameObject ship = newGameObject.shipBulderRigidBody.RBody().shipBulderSound.Sound(audioClip);
         
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
