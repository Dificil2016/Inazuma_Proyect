using System;
using UnityEngine;

[Serializable]
public class CharaInstance
{
    public CharaData data;

    [Range(1, 99)]
    public int level = 1;

    public int shirtNumber;

    public int currentPT;

    public int currentPE;

    public int GetStat(int maxStat)
    {
        return Mathf.RoundToInt(
            5 + ((maxStat - 5) / 98f) * (level - 1)
        );
    }

    public Stats GetStatsByLevel()
    {
        return new Stats()
        {
            kick = GetStat(data.stats.kick),
            dribble = GetStat(data.stats.dribble),
            block = GetStat(data.stats.block),
            speed = GetStat(data.stats.speed),
            control = GetStat(data.stats.control),
            stamina = GetStat(data.stats.stamina),
            technique = GetStat(data.stats.technique),
            critical = GetStat(data.stats.critical),
        };
    }

    public CharaInstance(CharaData data)
    {
        this.data = data;

        level = 1;

        currentPT = data.maxPT;

        currentPE = data.maxPE;
    }

}