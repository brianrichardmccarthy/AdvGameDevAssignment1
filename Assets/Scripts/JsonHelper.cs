using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Code taken from https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
/// 
/// </summary>
public static class JsonHelper {

    public static List<T> FromJson<T>(string json) {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(List<T> array, bool format = false) {
        Wrapper<T> wrapper = new Wrapper<T>() {
            Items = array
        };
        return JsonUtility.ToJson(wrapper, format);
    }

    [Serializable]
    private class Wrapper<T> {
        public List<T> Items;
    }

}
