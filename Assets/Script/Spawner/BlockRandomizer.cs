
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockRandomizer
{
    private Block[] _sortList;
    
    public BlockRandomizer(Block[] blocks)
    {
        _sortList = blocks.OrderBy(x => x.GetSpawnChance()).ToArray();
        for (int i = 0; i < _sortList.Length; i++)
        {
            Debug.Log(_sortList[i]);
        }
    }
    
    public int GenerateSpawnedBlockIndex()
    {
        int range = Random.Range(0, 100);
        Debug.Log(range);
        for (int i = 0; i < _sortList.Length; i++)
        {
            if (range < _sortList[i].GetSpawnChance())
            {
                return i;
            }
        }

        return -1;
    }
}
