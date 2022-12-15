using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T> where T : MonoBehaviour
{
    public T prefab { get; }

    public Transform startPoint { get; }

    private List<T> moneyList;

    public ObjectsPool(T pref, Transform startP, int count)
    {
        this.prefab = pref;
        this.startPoint = startP;

        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        this.moneyList = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();

        }
    }

    private T CreateObject(bool isActiveDefault = false)
    {
        T newObject = Object.Instantiate(this.prefab, this.startPoint);
        newObject.gameObject.SetActive(isActiveDefault);
        this.moneyList.Add(newObject);
        return newObject;
    }

    private bool IsFreeElement(out T element)
    {
        foreach (var o in moneyList)
        {
            if (!o.gameObject.activeInHierarchy)
            {
                element = o;
                o.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.IsFreeElement(out T element))
        {
            return element;
        }
        return this.CreateObject(true);
    }



}
