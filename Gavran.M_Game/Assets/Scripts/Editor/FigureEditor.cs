using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace GavranGame.Editor
{
    [CustomEditor(typeof(Figure))]
    public class FigureEditor : UnityEditor.Editor
    {
        private int offset = 20;
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            Figure figure = (Figure) target;

            EditorGUILayout.LabelField("Размер");
            figure.changeScale = EditorGUILayout.Slider(figure.changeScale, 1, 10);
            
            EditorGUILayout.Space(20);

            GUI.backgroundColor = Color.black;
            GUI.contentColor = Color.red;
            if (GUILayout.Button("Сбросить трансформ"))
            {
                figure.ResrtTransform();
                figure.changeScale = 1f;
            }
            
            EditorGUILayout.Space(offset);
            
            GUI.backgroundColor = Color.red;
            GUI.contentColor = Color.white;
            if (GUILayout.Button("Сгенерировать цвет"))
            {
                figure.GenerateColor();
            }
            
            EditorGUILayout.Space(offset);
            
            GUI.backgroundColor = Color.yellow;
            GUI.contentColor = Color.green;
            if (GUILayout.Button("Добавить нужные компоненты"))
            {
                figure.AddNeedComponent();
            }
            
            EditorGUILayout.Space(offset);
            
            GUI.backgroundColor = Color.blue;
            GUI.contentColor = Color.yellow;
            if (GUILayout.Button("Удалить компоненты"))
            {
                figure.RemoveComponent();
            }


            figure.ChangeScale( figure.changeScale);
        }
    }
}