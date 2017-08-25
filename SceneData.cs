/*

	SceneData Component Class

	Phil Garner

	Attach this to a GameObject to store and retrieve
	object data on demand.

	Example applications:
	-Store player position before changing levels and then recall the position data when changing back.
	-Store inventory object instances on the GameObject directly.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {

    private class DataCollection
    {

        private Dictionary<string, object> _data = new Dictionary<string, object>();

        public void SetData(string key, object value)
        {
            if (_data.ContainsKey(key))
            {
                _data[key] = value;
            }
            else
            {
                _data.Add(key, value);
            }
        }

        public object GetData(string key)
        {
            if (_data.ContainsKey(key))
            {
                return _data[key];
            }
            else
            {
                return null;
            }
        }

    }

    private Dictionary<string, DataCollection> _sceneData = new Dictionary<string, DataCollection>();

    public object GetData(string sceneName, string key)
    {
        if (_sceneData.ContainsKey(sceneName))
        {
            return _sceneData[sceneName].GetData(key);
        }
        else
        {
            return null;
        }
    }
    public void SetData(string sceneName, string key, object value)
    {
        if (!_sceneData.ContainsKey(sceneName))
        {
            _sceneData.Add(sceneName, new DataCollection());
        }
        _sceneData[sceneName].SetData(key, value);
    }
	
}
