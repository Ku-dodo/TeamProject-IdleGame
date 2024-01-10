using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private Dictionary<string, GameObject> models = new();
    private Dictionary<string, Sprite> sprites = new();

    /// <summary>
    /// Resources ���� �� ������ �ҷ�����
    /// </summary>
    public void Initialize()
    {
        LoadPrefabs("Prefabs/Models", models);
        LoadSprites("Sprites", sprites);
    }

    #region Prefab

    /// <summary>
    /// ������ ��� �ȿ� ��� �����յ� �ε�
    /// </summary>
    /// <param name="path">���� ���</param>
    /// <param name="prefabs">�ε��� ������ ��</param>
    private void LoadPrefabs(string path, Dictionary<string, GameObject> prefabs)
    {
        GameObject[] objs = Resources.LoadAll<GameObject>(path);
        foreach (GameObject obj in objs)
        {
            prefabs[obj.name] = obj;
        }
    }

    /// <summary>
    /// string key�� ������� ������Ʈ ��������
    /// </summary>
    /// <param name="prefabName"></param>
    /// <returns></returns>
    public GameObject GetObject(string prefabName)
    {
        if (!models.TryGetValue(prefabName, out GameObject prefab)) return null;
        return prefab;
    }

    #endregion

    #region Sprite

    /// <summary>
    /// ������ ��� �ȿ� ��� ��������Ʈ �ε�
    /// </summary>
    /// <param name="path">���� ���</param>
    /// <param name="sprites">�ε��� ��������Ʈ ��</param>
    private void LoadSprites(string path, Dictionary<string, Sprite> sprites)
    {
        Sprite[] objs = Resources.LoadAll<Sprite>(path);
        foreach (Sprite obj in objs)
        {
            sprites[obj.name] = obj;
        }
    }

    public Sprite GetSprite(string spriteName)
    {
        if (!sprites.TryGetValue(spriteName, out Sprite sprite)) return null;
        return sprite;
    }

    #endregion
}
