using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VampireSurvivors;
using VampireSurvivors.Lib.Basic.Completables;

public class VSSceneManager
{

    private static readonly Dictionary<string, SceneEntry> _sceneEntries = new Dictionary<string, SceneEntry>();


    public VSSceneManager()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.sceneUnloaded += SceneUnloaded;
    }


    public Completable<T> LoadAdditive<T>(string a_key) where T : SceneEntry
    {
        if (_sceneEntries.ContainsKey(a_key))
        {
            return null;
        }
        _sceneEntries.Add(a_key, null);

        Completable<T> completable = new Completable<T>();
        AsyncOperation scene = SceneManager.LoadSceneAsync(a_key, LoadSceneMode.Additive);
        scene.completed += (_) =>
        {
            if (TryGetSceneEntry(a_key, out T sceneEntry))
            {
                completable.Value = sceneEntry;
                completable.Complete();
            }

        };
        return completable;
    }


    public Completable<T> Unload<T>(string a_key) where T : SceneEntry
    {
        Completable<T> completable = new Completable<T>();
        if (_sceneEntries.TryGetValue(a_key, out SceneEntry sceneEntry))
        {
            sceneEntry.Unload();
        }
        AsyncOperation scene = SceneManager.UnloadSceneAsync(a_key);
        scene.completed += (_) => { completable.Complete(); };
        return completable;
    }



    private bool TryGetSceneEntry<T>(string a_key, out T a_sceneEntry) where T : SceneEntry
    {
        if (_sceneEntries.TryGetValue(a_key, out SceneEntry sceneEntry))
        {

            if (sceneEntry is T entry)
            {
                a_sceneEntry = entry;
                return true;
            }
        }
        a_sceneEntry = null;
        return false;
    }


    private void SceneLoaded(Scene a_scene, LoadSceneMode a_loadSceneMode)
    {
        if(_sceneEntries.TryGetValue(a_scene.name, out SceneEntry sceneentry))
        {
            if (sceneentry != null)
            {
                return;
            }
        }
        else { return; }

        GameObject[] gameObjects = a_scene.GetRootGameObjects();
        foreach (GameObject go in gameObjects)
        {
            SceneEntry sceneEntry = go.GetComponent<SceneEntry>();
            if (sceneEntry != null)
            {
                _sceneEntries[a_scene.name]= sceneEntry;
                sceneEntry.Load();
                break;
            }
        }
    }


    private void SceneUnloaded(Scene a_scene)
    {
        if (_sceneEntries.ContainsKey(a_scene.name))
        {
            _sceneEntries.Remove(a_scene.name);            
        }
    }

}
