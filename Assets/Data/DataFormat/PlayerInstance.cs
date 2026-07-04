using UnityEngine;

[System.Serializable]
public class PlayerInstance
{
    public PlayerData data;

    public int level;

    public int experience;

    public int currentPE;

    public int currentPT;

    public LearnedHissatsu[] hissatsus = new LearnedHissatsu[6];

    public HissatsuData InherentSkill => data.inherentSkill;

    public PlayerInstance(PlayerData playerData, int initialLevel)
    {
        data = playerData;

        level = Mathf.Clamp(initialLevel, 1, 99);

        experience = 0;

        currentPE = GetMaxPE();
        currentPT = GetMaxPT();

        for (int i = 0; i < hissatsus.Length; i++)
        {
            hissatsus[i] = new LearnedHissatsu();

            hissatsus[i].data = data.hissatsus[i];
            hissatsus[i].level = 0;
        }
    }

    //---------------------------------------------------------
    // STATS
    //---------------------------------------------------------

    int CalculateStat(int statValue)
    {
        return 5 + Mathf.RoundToInt(((statValue - 5f) / 98f) * (level - 1));
    }

    public int GetShooting() => CalculateStat(data.shooting);

    public int GetDribbling() => CalculateStat(data.dribbling);

    public int GetDefense() => CalculateStat(data.defense);

    public int GetPhysique() => CalculateStat(data.physique);

    public int GetTechnique() => CalculateStat(data.technique);

    public int GetSpeed() => CalculateStat(data.speed);

    public int GetStamina() => CalculateStat(data.stamina);

    public int GetLuck() => CalculateStat(data.luck);

    public int GetMaxPE() => CalculateStat(data.maxPE);

    public int GetMaxPT() => CalculateStat(data.maxPT);

    //---------------------------------------------------------
    // HISSATSUS
    //---------------------------------------------------------

    public bool ChangeHissatsu(int slot, HissatsuData newHissatsu)
    {
        if (slot < 0 || slot >= hissatsus.Length)
            return false;

        if (newHissatsu == null)
        {
            hissatsus[slot].data = null;
            hissatsus[slot].level = 0;
            return true;
        }

        // No permitir equipar la skill inherente
        if (newHissatsu == data.inherentSkill)
            return false;

        // No permitir equipar una técnica original
        foreach (var hissatsu in data.hissatsus)
        {
            if (hissatsu == newHissatsu)
                return false;
        }

        // No permitir duplicados
        foreach (var hissatsu in hissatsus)
        {
            if (hissatsu.data == newHissatsu)
                return false;
        }

        hissatsus[slot].data = newHissatsu;
        hissatsus[slot].level = 0;

        return true;
    }
}

[System.Serializable]
public class LearnedHissatsu
{
    public HissatsuData data;

    public int level;
}
