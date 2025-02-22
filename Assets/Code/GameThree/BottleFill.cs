using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BottleFill : MonoBehaviour
    {
        private CapsuleCollider2D coll;
        private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite fullBottle;

        int bottlePoints = 0;
        public AudioSource ASBottleFill;

        // Start is called before the first frame update
        void Awake()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            coll = GetComponent<CapsuleCollider2D>();
        }

        //Destroy winedrop when it reached a bottle and trigger sprite change for bottle
        //Trigger bottle will sound
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "WineDrop")
            {
                ASBottleFill.Play();
                Destroy(collision.gameObject);
                ChangeSprite();
                bottlePoints += 1;
                ScoreManager.instance.AddPoint();
            }

        }

        //method that changes sprite to a full bottle sprite
        public void ChangeSprite()  
        {
            spriteRenderer.sprite = fullBottle;
        }

    }
}
