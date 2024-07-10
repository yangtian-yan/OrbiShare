using UnityEngine;
using Oculus.Interaction.Surfaces;

public class SphereSurfacePatch : MonoBehaviour, ISurfacePatch
{
    private SphereCollider _sphereCollider;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        if (_sphereCollider == null)
        {
            Debug.LogError("SphereSurfacePatch requires a SphereCollider component.");
        }
    }

    public bool ClosestSurfacePoint(in Vector3 point, out SurfaceHit hit, float maxDistance = float.MaxValue)
    {
        Debug.Log("ClosestSurfacePoint called");
        hit = new SurfaceHit();
        if (_sphereCollider == null)
        {
            Debug.LogError("SphereCollider is null");
            return false;
        }

        Vector3 center = _sphereCollider.transform.position + _sphereCollider.center;
        Vector3 direction = (point - center).normalized;
        Vector3 closestPoint = center + direction * _sphereCollider.radius;

        float distance = Vector3.Distance(point, closestPoint);
        Debug.Log($"ClosestPoint: {closestPoint}, Distance: {distance}");
        if (distance > maxDistance)
        {
            return false;
        }

        hit.Point = closestPoint;
        hit.Normal = direction;
        hit.Distance = distance;
        return true;
    }

    public bool BackingSurfaceClosestSurfacePoint(in Vector3 point, out SurfaceHit hit)
    {
        // For a sphere, the backing surface can be considered the same as the surface itself.
        return ClosestSurfacePoint(point, out hit);
    }

    public bool Raycast(in Ray ray, out SurfaceHit hit, float maxDistance = float.MaxValue)
    {
        Debug.Log("Raycast called");
        hit = new SurfaceHit();
        if (_sphereCollider == null)
        {
            Debug.LogError("SphereCollider is null");
            return false;
        }

        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, maxDistance) && raycastHit.collider == _sphereCollider)
        {
            hit.Point = raycastHit.point;
            hit.Normal = raycastHit.normal;
            hit.Distance = raycastHit.distance;
            Debug.Log($"RaycastHit: {hit.Point}, Distance: {hit.Distance}");
            return true;
        }

        return false;
    }

    public Transform Transform
    {
        get
        {
            return this.transform;
        }
    }

    public ISurface BackingSurface
    {
        get
        {
            return this;
        }
    }
}

