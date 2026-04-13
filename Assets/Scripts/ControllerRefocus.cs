using UnityEngine;
using UnityEngine.EventSystems;

// If there is no selected item, set the selected item to the event system's first selected item
public class ControllerRefocus : MonoBehaviour
{
    public GameObject lastselect;
    //public bool UsingController;

    void Start()
    {
        lastselect = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }

        //if (!UsingController)
        //{
        //    EventSystem.current.SetSelectedGameObject(null);
        //}
    }

}
