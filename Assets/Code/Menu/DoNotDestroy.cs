using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class DoNotDestroy : MonoBehaviour
    {
        private void Awake()
        {
            //Make music continue without stopping
            GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
            if (musicObj.Length > 1 ) 
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);

        }



    }
}


