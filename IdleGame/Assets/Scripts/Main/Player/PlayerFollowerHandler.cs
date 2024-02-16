using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerHandler : MonoBehaviour
{
    [SerializeField] private Transform[] _followerPosition;

    private Dictionary<int, EquipFollowerData> _userEquipFollowerSlot = new Dictionary<int, EquipFollowerData>();

    public void InitFollowerSlot()
    {
        int equipslotIndex = 0;
        foreach (var item in Manager.Data.FollowerData.UserEquipFollower)
        {
            var go = new GameObject("FollowerObj");
            go.transform.parent = transform;
            _userEquipFollowerSlot.Add(equipslotIndex, go.AddComponent<EquipFollowerData>());
            _userEquipFollowerSlot[equipslotIndex].SetFollowerObject(Manager.Data.FollowerData.UserEquipFollower[equipslotIndex].itemID, _followerPosition[equipslotIndex]);
            equipslotIndex++;
        }
    }

    public void ChangeEquipFollowerData(int slotIndex)
    {
        _userEquipFollowerSlot[slotIndex].SetFollowerObject(Manager.Data.FollowerData.UserEquipFollower[slotIndex].itemID, _followerPosition[slotIndex]);
    }
}

public class EquipFollowerData: MonoBehaviour
{
    public GameObject FollowerObject { get; private set; }

    public Follower FollowerScript { get; private set; }

    public void SetFollowerObject(string itemID, Transform spawntransform)
    {
        if(itemID == "Empty")
        {
            if(FollowerObject != null)
            {
                Destroy(FollowerObject);
                FollowerScript = null;
            }
            return;
        }

        if(FollowerObject != null)
        {
            Destroy (FollowerObject);
            FollowerScript = null;
        }

        var followerBlueprint = Manager.FollowerData.FollowerDataDictionary[itemID];
        FollowerObject = Manager.Address.InstantiatePrefab(followerBlueprint.FollowerObject.name, spawntransform);        
        FollowerScript = FollowerObject.GetComponent<Follower>();
        FollowerScript.Initialize(followerBlueprint);
    }
}