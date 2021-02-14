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
            GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

        public void AddNeedComponent()
        {
            if (!TryGetComponent(out BoxCollider boxCollider))
            {
                gameObject.AddComponent<BoxCollider>();
            }
            
            gameObject.AddComponent<Rigidbody>();
            gameObject.AddComponent<MeshRenderer>();
        }

        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<Rigidbody>());
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }
    
    
}