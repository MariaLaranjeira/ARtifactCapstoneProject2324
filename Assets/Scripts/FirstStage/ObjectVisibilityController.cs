using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    public GameObject[] objects;
    public int index;

    void Start()
    {
          if (objects.Length > 0)
        {
            index = Mathf.Clamp(index, 0, objects.Length - 1);

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == index);
            }
        }
    }

    public void HideAtEnd()
    {
        if (index < objects.Length)
        {
            objects[index].SetActive(false);
            index++;
        }
    }
}
