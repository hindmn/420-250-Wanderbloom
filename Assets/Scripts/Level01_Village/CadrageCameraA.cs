using UnityEngine;

namespace Arielle
{
    [ExecuteAlways]
    [RequireComponent(typeof(Camera))]
    public class CadrageCameraA : MonoBehaviour
    {
        [Header("Zone à toujours afficher")]
        [SerializeField] private float minX = -10f;
        [SerializeField] private float maxX = 10f;
        [SerializeField] private float minY = -4.5f;
        [SerializeField] private float maxY = 4.5f;

        private Camera cam;

        private void LateUpdate()
        {
            if (cam == null) cam = GetComponent<Camera>();

            float largeur = maxX - minX;
            float hauteur = maxY - minY;

            transform.position = new Vector3((minX + maxX) / 2f, (minY + maxY) / 2f, transform.position.z);

            cam.orthographicSize = Mathf.Max(hauteur / 2f, largeur / 2f / cam.aspect);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Vector3 centre = new Vector3((minX + maxX) / 2f, (minY + maxY) / 2f, 0f);
            Gizmos.DrawWireCube(centre, new Vector3(maxX - minX, maxY - minY, 0f));
        }
    }
}