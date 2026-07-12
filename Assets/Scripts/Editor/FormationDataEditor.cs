using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FormationData))]
public class FormationDataEditor : Editor
{
    private FormationData formation;

    private const float FieldSize = 420f;
    private const float PlayerRadius = 10f;

    private int draggingPlayer = -1;

    private void OnEnable()
    {
        formation = (FormationData)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(15);

        GUILayout.Label("Formation Editor", EditorStyles.boldLabel);

        Rect fieldRect = GUILayoutUtility.GetRect(
            FieldSize,
            FieldSize,
            GUILayout.ExpandWidth(false));

        DrawField(fieldRect);

        HandleEvents(fieldRect);

        if (GUI.changed)
            Repaint();
    }

    private void DrawField(Rect rect)
    {
        EditorGUI.DrawRect(rect, new Color(0.18f, 0.55f, 0.25f));

        Handles.BeginGUI();

        DrawGrid(rect);

        DrawPitch(rect);

        DrawPlayers(rect);

        Handles.EndGUI();
    }

    private void DrawGrid(Rect rect)
    {
        Handles.color = new Color(1, 1, 1, .12f);

        for (int i = 1; i < 4; i++)
        {
            float x = Mathf.Lerp(rect.x, rect.xMax, i / 4f);

            Handles.DrawDottedLine(
                new Vector3(x, rect.y),
                new Vector3(x, rect.yMax),
                4);

            float y = Mathf.Lerp(rect.y, rect.yMax, i / 4f);

            Handles.DrawDottedLine(
                new Vector3(rect.x, y),
                new Vector3(rect.xMax, y),
                4);
        }
    }

    private void DrawPitch(Rect rect)
    {
        Handles.color = Color.white;

        // Borde
        Handles.DrawSolidRectangleWithOutline(
            rect,
            Color.clear,
            Color.white);

        // Línea del centro
        Handles.DrawLine(
            new Vector3(rect.x, rect.y),
            new Vector3(rect.xMax, rect.y));

        // Semicírculo central
        Handles.DrawWireArc(
            new Vector3(rect.center.x, rect.y),
            Vector3.forward,
            Vector3.left,
            -180,
            rect.width * .15f);

        // Área grande
        float bigWidth = rect.width * .45f;
        float bigHeight = rect.height * .18f;

        Rect penaltyArea = new Rect(
            rect.center.x - bigWidth / 2,
            rect.yMax - bigHeight,
            bigWidth,
            bigHeight);

        Handles.DrawSolidRectangleWithOutline(
            penaltyArea,
            Color.clear,
            Color.white);

        // Área pequeña
        float smallWidth = rect.width * .22f;
        float smallHeight = rect.height * .08f;

        Rect goalArea = new Rect(
            rect.center.x - smallWidth / 2,
            rect.yMax - smallHeight,
            smallWidth,
            smallHeight);

        Handles.DrawSolidRectangleWithOutline(
            goalArea,
            Color.clear,
            Color.white);

        // Punto de penalti
        Handles.DrawSolidDisc(
            new Vector2(rect.center.x, rect.yMax - rect.height * .12f),
            Vector3.forward,
            2);

        // Portería
        float goalWidth = rect.width * .18f;

        Handles.DrawLine(
            new Vector3(rect.center.x - goalWidth / 2, rect.yMax),
            new Vector3(rect.center.x - goalWidth / 2, rect.yMax + 8));

        Handles.DrawLine(
            new Vector3(rect.center.x + goalWidth / 2, rect.yMax),
            new Vector3(rect.center.x + goalWidth / 2, rect.yMax + 8));

        Handles.DrawLine(
            new Vector3(rect.center.x - goalWidth / 2, rect.yMax + 8),
            new Vector3(rect.center.x + goalWidth / 2, rect.yMax + 8));
    }

    private void DrawPlayers(Rect rect)
    {
        for (int i = 0; i < formation.positions.Count; i++)
        {
            Vector2 normalized = formation.positions[i];

            Vector2 screen = new Vector2(
                rect.x + normalized.x * rect.width,
                rect.y + (1f - normalized.y) * rect.height);

            Handles.color = Color.white;

            Handles.DrawSolidDisc(
                screen,
                Vector3.forward,
                PlayerRadius);

            Handles.color = Color.black;

            GUIStyle style = new GUIStyle(EditorStyles.boldLabel)
            {
                alignment = TextAnchor.MiddleCenter
            };

            style.normal.textColor = Color.black;

            GUI.Label(
                new Rect(
                    screen.x - 10,
                    screen.y - 8,
                    20,
                    16),
                (i).ToString(),
                style);
        }
    }

    private void HandleEvents(Rect rect)
    {
        Event e = Event.current;

        switch (e.type)
        {
            case EventType.MouseDown:

                for (int i = 0; i < formation.positions.Count; i++)
                {
                    Vector2 p =
                        new Vector2(
                            rect.x + formation.positions[i].x * rect.width,
                            rect.y + (1f - formation.positions[i].y) * rect.height);

                    if (Vector2.Distance(e.mousePosition, p) < PlayerRadius + 4)
                    {
                        draggingPlayer = i;

                        e.Use();

                        break;
                    }
                }

                break;

            case EventType.MouseDrag:

                if (draggingPlayer != -1)
                {
                    Undo.RecordObject(
                        formation,
                        "Move Player");

                    Vector2 pos = e.mousePosition;

                    formation.positions[draggingPlayer] =
                        new Vector2(
                            Mathf.Clamp01((pos.x - rect.x) / rect.width),
                            Mathf.Clamp01(1f - ((pos.y - rect.y) / rect.height)));

                    EditorUtility.SetDirty(formation);

                    GUI.changed = true;

                    e.Use();
                }

                break;

            case EventType.MouseUp:

                draggingPlayer = -1;

                break;
        }
    }
}