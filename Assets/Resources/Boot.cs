using UnityEngine;

public static class Boot {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute() {
        Object.DontDestroyOnLoad(Object.Instantiate(Resources.Load("GlobalSystems")));
    }
}