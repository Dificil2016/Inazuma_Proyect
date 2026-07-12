using System.Collections.Generic;
using System;

[Serializable]
public class TeamInstance
{
    public string teamName;
    public FormationData formation;
    public List<CharaInstance> players = new();

    public int score;
}