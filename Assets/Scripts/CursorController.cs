using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    private Texture2D momCursor;
    [SerializeField]
    private Texture2D neveraCursor;
    [SerializeField]
    private Texture2D moveCursor;

    [SerializeField]
    private Texture2D dormirCursor;
    [SerializeField]
    private Texture2D infoCursor;
    [SerializeField]
    private Texture2D closeCursor;

    [SerializeField]
    private Texture2D doorCursor;

    public static CursorController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

/** 
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            if(hitInfo.collider.GetComponent<ClickableObjectCursor>() != null)
            {
                SetClickableCursor();
            }
            else
            {
                SetMoveCursor();
            }
        }
    }
*/
    public void SetMoveCursor()
    {
        Cursor.SetCursor(moveCursor, Vector2.zero, CursorMode.Auto);
    }

     public void SetDormirCursor()
    {
        Cursor.SetCursor(dormirCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetMomCursor()
    {
        Cursor.SetCursor(momCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetNeveraCursor()
    {
        Cursor.SetCursor(neveraCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetClickableCursor()
    {
        Cursor.SetCursor(momCursor, Vector2.zero, CursorMode.Auto);
    }

     public void SetInfoCursor()
    {
        Cursor.SetCursor(infoCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetCloseCursor()
    {
        Cursor.SetCursor(closeCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetDoorCursor()
    {
        Cursor.SetCursor(doorCursor, Vector2.zero, CursorMode.Auto);
    }

}
