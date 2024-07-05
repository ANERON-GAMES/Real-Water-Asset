using UnityEngine;

public class Visualization_Collider : MonoBehaviour
{
    private Collider2D _Collider2D;
    [Header("Gizmos")]
    public bool GizmosMode = true;
    public Color GizmosColor = Color.red;
    [SerializeField] private Vector2 GizmosSize = new Vector2(1f, 1f);
    private void Awake()
    {
        CheckComponents();
    }
    private void OnDrawGizmos()
    {
        if (GizmosMode)
        {
            Gizmos.color = GizmosColor;

            BoxCollider2D boxCollider = _Collider2D as BoxCollider2D;
            if (boxCollider != null)
            {
                Matrix4x4 matrixBackup = Gizmos.matrix;
                Matrix4x4 transformationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
                Gizmos.matrix = transformationMatrix;
                Vector2 colliderSize = boxCollider.size * GizmosSize;
                Gizmos.DrawWireCube(boxCollider.offset, colliderSize);
                Gizmos.matrix = matrixBackup;
            }
            else if (_Collider2D is CapsuleCollider2D capsuleCollider)
            {
                Matrix4x4 matrixBackup = Gizmos.matrix;
                Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
                Vector2 colliderSize = new Vector2(capsuleCollider.size.x * GizmosSize.x * transform.localScale.x,
                                                   capsuleCollider.size.y * GizmosSize.y * transform.localScale.y);
                Vector2 offset = capsuleCollider.offset;
                if (capsuleCollider.direction == CapsuleDirection2D.Vertical)
                {
                    Gizmos.DrawWireCube(offset, new Vector3(colliderSize.x, colliderSize.y - colliderSize.x, 0));
                    Gizmos.DrawWireSphere(offset + Vector2.up * (colliderSize.y - colliderSize.x) / 2, colliderSize.x / 2);
                    Gizmos.DrawWireSphere(offset - Vector2.up * (colliderSize.y - colliderSize.x) / 2, colliderSize.x / 2);
                }
                else
                {
                    Gizmos.DrawWireCube(offset, new Vector3(colliderSize.x - colliderSize.y, colliderSize.y, 0));
                    Gizmos.DrawWireSphere(offset + Vector2.right * (colliderSize.x - colliderSize.y) / 2, colliderSize.y / 2);
                    Gizmos.DrawWireSphere(offset - Vector2.right * (colliderSize.x - colliderSize.y) / 2, colliderSize.y / 2);
                }
                Gizmos.matrix = matrixBackup;
            }
        }
    }
    private void OnValidate()
    {
        CheckComponents();
    }
    private void CheckComponents()
    {
        if (_Collider2D == null) _Collider2D = GetComponent<Collider2D>();
        if (_Collider2D == null)
        {
            Debug.LogError("Object: " + gameObject.name + " | Script: " + GetType().Name + " | Collider2D is missing. Please attach a Collider2D component to the object.");
            return;
        }
    }
}