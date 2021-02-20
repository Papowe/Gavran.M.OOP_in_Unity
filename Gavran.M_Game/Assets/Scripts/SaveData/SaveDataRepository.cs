using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

namespace GavranGame
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);

            

        }

        public void Save(PlayerBase player, List<GoodBonus> goodBonusList)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var savePlayer = new SavedData();
            savePlayer.Position = player.transform.position;
            savePlayer.Name = "Misha";
            savePlayer.IsEnable = true;

            for (int i = 0; i < goodBonusList.Count; i++)
            {
                savePlayer.Bonuses.Add(new BonusesObject(
                    nameBonus: goodBonusList[i].name,
                    meshBonus: goodBonusList[i].gameObject.GetMeshRendererEnabled(),
                    colliderBonus: goodBonusList[i].gameObject.GetColliderEnabled()
                    ));
            }

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase player, List<GoodBonus> goodBonusList)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnable);

            for (int i = 0; i < newPlayer.Bonuses.Count; i++)
            {
                goodBonusList[i].name = newPlayer.Bonuses[i].nameBonus;
                goodBonusList[i].GetComponent<MeshRenderer>().enabled = newPlayer.Bonuses[i].meshBonus;
                goodBonusList[i].GetComponent<BoxCollider>().enabled = newPlayer.Bonuses[i].colliderBonus;
            }

            Debug.Log(newPlayer);
        }
    }

}