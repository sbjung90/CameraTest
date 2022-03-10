using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            //if (applicationIsQuitting)
            //{
            //    Log4Cs.LogWarning("[Singleton] Instance '" + typeof(T) +
            //                     "' already destroyed on application quit." +
            //                     " Won't create again - returning null.");
            //    return null;
            //}

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Log4Cs.LogError("[Singleton] Something went really wrong " +
                                       " - there should never be more than 1 singleton!" +
                                       " Reopenning the scene might fix it.");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();

                        DontDestroyOnLoad(singleton);

                        Log4Cs.Log("[Singleton] An instance of " + typeof(T) +
                                  " is needed in the scene, so '" + singleton +
                                  "' was created with DontDestroyOnLoad.");
                    }
                    else
                    {
                        Log4Cs.Log("[Singleton] Using instance already created: " +
                                  _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }
    }

    //private static bool applicationIsQuitting = false;


#if UNITY_EDITOR
    private void Awake()
    {
        StartService();
    }
#endif

    public virtual void StartService()
    {
    }

    public static bool IsInstance
    {
        get => _instance != null;
    }

    public virtual void OnDestroy()
    {
      //  applicationIsQuitting = true;
    }
}
