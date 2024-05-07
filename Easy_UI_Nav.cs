using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEditor;
using System;

public class Easy_UI_Nav : MonoBehaviour
{

    public string NavName; // This is used just for organization purposes, this
                           // could be removed without any reprecussion
    public List<UINavigator> navs; // This is important

    private void Awake()
    {
        foreach (UINavigator item in navs)
        {

            item.UserChosenButton.onClick.AddListener(
                () => EnableAll(item.ItemsToEnable));
            item.UserChosenButton.onClick.AddListener(
                () => DisableAll(item.ItemsToDisable));
        }
    } // On awake, we will take the user selected button and add the proper
      // listeners for enabling and disabling gameobjects

    void EnableAll(List<GameObject> glist)
    {
        foreach (GameObject g in glist)
        {
            g.SetActive(true);
        }
    } // The function to enable gameobjects

    void DisableAll(List<GameObject> glist)
    {
        foreach (GameObject game in glist)
        {
            game.SetActive(false);
        }
    } // The function to disable gameobjects
}

[System.Serializable]

public class UINavigator
{

    public Button UserChosenButton; // The button that will have listeners
                                    // attached
    public List<GameObject> ItemsToEnable; // The objects which will be enabled
    public List<GameObject> ItemsToDisable; // The objects which will be disabled

    public UINavigator(
        Button userbutton, List<GameObject> enables, List<GameObject> disables)
    {
        UserChosenButton = userbutton;
        ItemsToEnable = enables;
        ItemsToDisable = disables;
    }
}

// Thank you
// https://stackoverflow.com/questions/67578533/serialize-observablecollection-like-class-observablelist-in-unity-c-sharp
// for making the Observed List class! Basically pasted here


[Serializable]
public class ObservedList<T> : IList<T>
{
    public delegate void ChangedDelegate(int index, T oldValue, T newValue);

    [SerializeField]
    private List<T> _list
        = new List<T>();

    // NOTE: I changed the signature to provide a bit more information
    // now it returns index, oldValue, newValue
    public event ChangedDelegate Changed;

    public event Action Updated;

    public IEnumerator<T> GetEnumerator() { return _list.GetEnumerator(); }

    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

    public void Add(T item)
    {
        _list.Add(item);
        Updated?.Invoke();
    }

    public void Clear()
    {
        _list.Clear();
        Updated?.Invoke();
    }

    public bool Contains(T item) { return _list.Contains(item); }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
    {
        var output = _list.Remove(item);
        Updated?.Invoke();

        return output;
    }

    public int Count => _list.Count;
    public bool IsReadOnly => false;

    public int IndexOf(T item) { return _list.IndexOf(item); }

    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
        Updated?.Invoke();
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
        Updated?.Invoke();
    }

    public void AddRange(IEnumerable<T> collection)
    {
        _list.AddRange(collection);
        Updated?.Invoke();
    }

    public void RemoveAll(Predicate<T> predicate)
    {
        _list.RemoveAll(predicate);
        Updated?.Invoke();
    }

    public void InsertRange(int index, IEnumerable<T> collection)
    {
        _list.InsertRange(index, collection);
        Updated?.Invoke();
    }

    public void RemoveRange(int index, int count)
    {
        _list.RemoveRange(index, count);
        Updated?.Invoke();
    }

    public T this[int index]
    {
        get { return _list[index]; }
        set
        {
            var oldValue = _list[index];
            _list[index] = value;
            Changed?.Invoke(index, oldValue, value);
            // I would also call the generic one here
            Updated?.Invoke();
        }
    }
}

[CustomEditor(typeof(Easy_UI_Nav))]
public class Easy_UI_NavEditor : Editor
{
    Easy_UI_Nav uiNav;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        uiNav = (Easy_UI_Nav)target;

        EditorGUILayout.Space();

        if (GUILayout.Button("Reinitialize"))
        {
            foreach (UINavigator item in uiNav.navs)
            {
                item.ItemsToDisable.Clear();
                item.ItemsToEnable.Clear();
            }
        } // When the Reinitialize button is clicked, the list of gameobjects to
          // enable and disable are cleared
    }
}

[System.Serializable]
public class KeyValue<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public KeyValue(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
} // Basically a version of the Dictionary Class for serializing
