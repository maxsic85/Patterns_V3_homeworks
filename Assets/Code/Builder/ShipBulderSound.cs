using UnityEngine;
namespace MSuhinin.Builder
{
    public class ShipBulderSound : ShipBuilder
    {
        private AudioClip clip;
        public ShipBulderSound(GameObject gameObject) : base(gameObject)
        {

        }

        public ShipBulderSound Sound(AudioClip audioClip)
        {
            GetOrAddComponent<AudioSource>();
            clip = audioClip;
            return this;
        }

        public void PlaySound()
        {
           shipBulderSound.GetOrAddComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}