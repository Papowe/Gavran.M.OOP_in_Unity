using System;
using UnityEditor;
using UnityEngine;

namespace GavranGame.Editor
{
    public class MyWindow : EditorWindow
    {
        [MenuItem("GavranGame/Мое окно")]
        private static void ShowWindow()
        {
            var window = GetWindow<MyWindow>();
            window.titleContent = new GUIContent("Окошко");
            window.Show();
        }
        
        public GameObject _prefabObject;
        public Vector3 _positionObject;
        public float _scale = 1;
        public string _nameObject = string.Empty;
        public bool _isToogleAddRb = true;
        public Color _materialColor = Color.red;
        public bool _isButtonCreate;
        public bool _isWarning = false;
        public string _messageWarning;
        
        private void OnGUI()
        {
            GUILayout.Label("Добавления объекта", EditorStyles.boldLabel);
            
            _prefabObject = EditorGUILayout.ObjectField(_prefabObject, typeof(GameObject), true) as GameObject;
            _positionObject = EditorGUILayout.Vector3Field("Position Object", _positionObject);
            
            EditorGUILayout.LabelField("Scale Object");
            _scale = EditorGUILayout.Slider(_scale, 1, 100);
            _nameObject = EditorGUILayout.TextField("Object Name: ", _nameObject);
            _isToogleAddRb = EditorGUILayout.Toggle("Add rigidbody", _isToogleAddRb);
            _materialColor = EditorGUILayout.ColorField("Color Object", _materialColor);
            _isButtonCreate = GUILayout.Button("Создать объект");
            if (_isWarning)
            {
                EditorGUILayout.HelpBox(_messageWarning, MessageType.Warning);
            }

            if (_isButtonCreate)
            {
                if (_prefabObject)
                {
                    if (_nameObject != String.Empty)
                    {
                        var gameObject = Instantiate(_prefabObject,_positionObject,Quaternion.identity);
                        gameObject.name = _nameObject;
                        gameObject.transform.localScale = new Vector3(_scale, _scale, _scale);
                        gameObject.GetComponent<Renderer>().sharedMaterial.color = _materialColor;
                        if (_isToogleAddRb)
                        {
                            if (!gameObject.TryGetComponent(out Rigidbody rigidbody))
                            {
                                gameObject.AddComponent<Rigidbody>();
                            }
                        }
                        _isWarning = false;
                    }
                    else
                    {
                        _messageWarning = "Нужно добавить имя объекту";
                        _isWarning = true;
                    }
                }
                else
                {
                    _messageWarning = "Нужно добавить обєкт в поле";
                    _isWarning = true;
                }
            }

        }
    }
}