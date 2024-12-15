using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _objectHolder;      // The parent GameObject containing 3D objects
    [SerializeField] private float _objectSpacing = 10f;   // Distance between objects along the X-axis
    [SerializeField] private float _snapSpeed = 0.5f;      // Speed for snapping back to position
    private float _targetPositionX;     // Target X position of the objectHolder
    private bool _isDragging = false;   // Indicates whether the user is currently dragging

    private void Awake()
    {
        _targetPositionX = _objectHolder.position.x; // Initialize the target position
    }

    private void Update()
    {
        if (!_isDragging)
        {
            SmoothSnap();
        }
    }

    // Called while dragging
    public void OnDrag(PointerEventData eventData)
    {
        _isDragging = true;

        // Move the objectHolder horizontally based on drag delta
        float dragDelta = eventData.delta.x * Time.deltaTime * 3f;
        _objectHolder.position += new Vector3(dragDelta, 0, 0);
    }

    // Called when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragging = false;

        // Determine the nearest object's index
        float nearestIndex = Mathf.Round(-_objectHolder.position.x / _objectSpacing);
        _targetPositionX = -nearestIndex * _objectSpacing;

        // Clamp the target position to prevent going out of bounds
        float maxPositionX = 0;
        float minPositionX = -_objectSpacing * (_objectHolder.childCount - 1);
        _targetPositionX = Mathf.Clamp(_targetPositionX, minPositionX, maxPositionX);
    }

    // Smoothly snap the objectHolder to the target position
    private void SmoothSnap()
    {
        Vector3 targetPosition = new Vector3(_targetPositionX, _objectHolder.position.y, _objectHolder.position.z);
        _objectHolder.position = Vector3.Lerp(_objectHolder.position, targetPosition, Time.deltaTime * _snapSpeed);
    }
}
