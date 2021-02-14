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

            GUI.color = Color.red;
            GUI.backgroundColor = Color.black;
            if (GUILayout.Button("Сбросить трансформ"))
            {
                figure.ResrtTransform();
                figure.changeScale = 1f;
            }
            
            EditorGUILayout.Space(offset);
            
            if (GUILayout.Button("Сгенерировать цвет"))
            {
                figure.GenerateColor();
            }
            
            EditorGUILayout.Space(offset);
            
            if (GUILayout.Button("Добавить нужные компоненты"))
            {
                figure.AddNeedComponent();
            }
            
            EditorGUILayout.Space(offset);
            
            if (GUILayout.Button("Удалить компоненты"))
            {
                figure.RemoveComponent();
            }


            figure.ChangeScale( figure.changeScale);
        }
    }
}