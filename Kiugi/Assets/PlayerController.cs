using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public List<Slime> ownedSlimes;
    public int level;
    public int GetMaxSpawnableSlime()
    {
        return level + 5;
    }

    public PlayerData()
    {
        ownedSlimes = new();
        level = 1;
    }
}

public class PlayerController : MonoBehaviour
{
    [Header("Drag Settings")]
    [SerializeField] private LayerMask draggableLayer;
    [SerializeField] private float dragHeight = 0f;
    [SerializeField] private float dragSmoothSpeed = 20f;

    private GameObject draggedObject;
    private Camera mainCamera;

    public static PlayerData playerData;

    private Rigidbody2D draggedRb;
    private bool originalKinematic;

    void Start()
    {
        mainCamera = Camera.main;
        playerData = new();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TryPickUp();

        if (Input.GetMouseButton(0) && draggedObject != null)
            DragObject();

        if (Input.GetMouseButtonUp(0) && draggedObject != null)
            DropObject();
    }

    void TryPickUp()
    {
        // 3D Ray 대신 2D 월드 포지션으로 변환
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Physics2D.OverlapPoint로 클릭 위치의 2D 콜라이더 감지
        Collider2D hit = Physics2D.OverlapPoint(worldPos, draggableLayer);

        if (hit != null)
        {
            draggedObject = hit.gameObject;

            draggedRb = draggedObject.GetComponent<Rigidbody2D>();
            if (draggedRb != null)
            {
                originalKinematic = draggedRb.isKinematic;
                draggedRb.isKinematic = true;
                draggedRb.angularVelocity = 0f;
            }
        }
    }

    void DragObject()
    {
        Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(mouseWorldPos.x, mouseWorldPos.y + dragHeight);

        draggedObject.transform.position = Vector2.Lerp(
            draggedObject.transform.position,
            targetPos,
            Time.deltaTime * dragSmoothSpeed
        );
    }

    void DropObject()
    {
        Vector2 origin = draggedObject.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, Mathf.Infinity, ~draggableLayer);

        if (hit.collider != null)
        {
            float halfHeight = 0f;
            if (draggedObject.TryGetComponent(out Collider2D col))
                halfHeight = col.bounds.extents.y;

            draggedObject.transform.position = new Vector2(hit.point.x, hit.point.y + halfHeight);
        }

        if (draggedRb != null)
        {
            draggedRb.isKinematic = originalKinematic;
            draggedRb = null;

        }
        draggedObject = null;
    }
}