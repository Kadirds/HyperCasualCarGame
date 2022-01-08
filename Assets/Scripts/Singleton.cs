using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
  private static Singleton _instance;
   public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Singleton>();
            }
            if (_instance == null)
            {
                _instance = new GameObject("Game Manager").AddComponent<Singleton>();
            }
            return _instance;
        }      
    }
    public int deger = 10;
    public float speed = 13.4f;
    private void Awake()
    {
        if (_instance != null) Destroy(this);
        DontDestroyOnLoad(this);

    }
}
