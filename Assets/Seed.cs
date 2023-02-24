using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {

    public static float randY;
    public static float randX;
    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod() {
        Seed.randX = Random.Range(0f, 9999f);
        Seed.randY = Random.Range(0f, 9999f);
    }
}
