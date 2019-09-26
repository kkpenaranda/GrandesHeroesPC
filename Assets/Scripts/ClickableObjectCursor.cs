using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObjectCursor : MonoBehaviour
{
    private void OnMouseEnter()
    {
        if(gameObject.name.Equals("Nevera"))
        {
            CursorController.Instance.SetNeveraCursor();
        }
        else if (gameObject.name.Equals("mom") || gameObject.name.Equals("calvo_7") || gameObject.name.Equals("nina_11"))
        {
            CursorController.Instance.SetMomCursor();
        }
        else if(gameObject.name.Equals("camaClick"))
        {
            CursorController.Instance.SetDormirCursor();
        }
        else if(gameObject.name.Equals("noticias") || gameObject.name.Equals("ButtonNews"))
        {
            CursorController.Instance.SetInfoCursor();
        }
        else if(gameObject.name.Equals("close"))
        {
            CursorController.Instance.SetCloseCursor();
        }
        else if (gameObject.name.Equals("Doors_Inside_70") || gameObject.name.Equals("Doors_Inside_6") || gameObject.name.Equals("PuertaCasa") || gameObject.name.Equals("PuertaCol") || gameObject.name.Equals("PuertaCoorp"))
        {
            CursorController.Instance.SetDoorCursor();
        }
    }

    private void OnMouseExit()
    {
        CursorController.Instance.SetMoveCursor();
    }
}
