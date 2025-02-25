/*  This file is part of the "Tanks Multiplayer" project by FLOBUK.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;
using UnityEngine.SceneManagement;

namespace TanksMP
{
    /// <summary>
    /// Script that makes child objects non-destroyable on scene changes.
    /// Only keeps one instance (the same) across the whole game.
    /// </summary>
    public class DontDestroyManager : MonoBehaviour
    {
        //reference to this script instance
        public static DontDestroyManager instance;
        
        //set the whole gameobject to 'dont destroy',
        //or destroy the other one if there's a duplicate
        public Scene defaultScene;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
                Destroy(gameObject);
        }
        void Start(){
            defaultScene = SceneManager.GetActiveScene();
        }
        public void ResetDestroyOnLoad() {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}