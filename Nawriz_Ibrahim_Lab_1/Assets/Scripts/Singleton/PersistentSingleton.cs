using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static readonly object lockObj = new object();
    private static bool applicationIsQuitting = false;

    /// <summary>
    /// Global access to the singleton instance. Lazily finds or creates the instance.
    /// Returns null if application is quitting.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (applicationIsQuitting) return null;

            if (instance != null) return instance;

            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = Object.FindFirstObjectByType<T>();

                    if (instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        instance = go.AddComponent<T>();
                        Object.DontDestroyOnLoad(go);
                    }
                }
            }

            return instance;
        }
    }

    /// <summary>
    /// Ensure singleton behavior when a derived component is instantiated in the scene.
    /// Derived classes can override and should call base.Awake().
    /// </summary>
    protected virtual void Awake()
    {
        if (applicationIsQuitting) return;

        if (instance == null)
        {
            instance = this as T;
            Object.DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}