using UnityEngine;

namespace GavranGame
{
    public class Figure : MonoBehaviour
    {
        public float changeScale = 1f;
        

        public void ChangeScale(float scale)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }

        public void ResrtTransform()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        public void GenerateColor()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.sharedMaterial.color = Random.ColorHSV();
            }
        }

        public void AddNeedComponent()
        {
            if (!TryGetComponent(out BoxCollider boxCollider))
            {
                gameObject.AddComponent<BoxCollider>();
            }
            
            gameObject.AddComponent<Rigidbody>();
            var mesh = gameObject.AddComponent<MeshRenderer>();
            mesh.material = new Material(Shader.Find("Standard"));
        }

        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<Rigidbody>());
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }
    
    
}