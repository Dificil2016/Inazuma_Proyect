using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public TeamInstance Team { get; private set; }

    public List<CharaController> Charas { get; } = new();

    [SerializeField]
    protected CharaController charaPrefab;

    public virtual void SetTeam(TeamInstance team)
    {
        Team = team;
    }

    public IEnumerator SetupCharas( MatchFieldSide field, bool hasKickOff)
    {
        // Destruir personajes anteriores
        foreach (CharaController chara in Charas)
        {
            if (chara != null)
            {
                Destroy(chara.gameObject);
                Debug.Log("XXX");
            }
        }

        Charas.Clear();

        // Calcular ejes locales del medio campo
        Vector3 horizontal = field.topRight.position - field.topLeft.position;

        Vector3 vertical =
            field.bottomLeft.position - field.topLeft.position;


        //GK
        CreateChara( Team.players[0], field.goalkeeperSpawn.position);

        //FieldPlayer
        int formationIndex = 0;

        for (int i = 1; i < Team.players.Count; i++)
        {
            bool kickOffPlayer = hasKickOff && (i >= Team.players.Count - 2);

            Vector3 spawnPosition;

            if (kickOffPlayer)
            {
                spawnPosition = (i == Team.players.Count - 2) ? field.kickOffPointA.position : field.kickOffPointB.position;
            }
            else
            {
                Vector2 normalized = Team.formation.positions[formationIndex];

                formationIndex++;

                spawnPosition = field.topLeft.position + horizontal * normalized.x + vertical * normalized.y;
            }

            CreateChara( Team.players[i], spawnPosition);
        }

        yield return null;
    }

    private void CreateChara(CharaInstance instance,Vector3 position)
    {
        CharaController controller = Instantiate(charaPrefab, position, Quaternion.identity);

        controller.Setup(instance);

        Charas.Add(controller);
    }
}