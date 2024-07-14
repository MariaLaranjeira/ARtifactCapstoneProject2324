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
            index = FirstStageGlobalState.characterSelected;

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
