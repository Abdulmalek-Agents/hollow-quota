using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace InventixGames.Core
{
    public static class SceneLoader { public static void LoadSceneAsync(string n, LoadSceneMode m = LoadSceneMode.Single) => CoroutineRunner.Run(R(n, m)); private static IEnumerator R(string n, LoadSceneMode m) { var op = SceneManager.LoadSceneAsync(n, m); op.allowSceneActivation = false; while (op.progress < 0.9f) { yield return null; } op.allowSceneActivation = true; } }
    public class CoroutineRunner : MonoBehaviour { private static CoroutineRunner _i; public static void Run(IEnumerator r) { if (_i == null) { var go = new GameObject("[CR]"); Object.DontDestroyOnLoad(go); _i = go.AddComponent<CoroutineRunner>(); } _i.StartCoroutine(r); } }
}
