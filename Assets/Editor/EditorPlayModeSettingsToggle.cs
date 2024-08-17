using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

[InitializeOnLoad]
public class EditorPlayModeSettingsToggle
{
    private static bool enterPlayModeOptionsEnabled;
    private static EnterPlayModeOptions enterPlayModeOptions;

    private const string EnterPlayModeOptionsEnabledPrefKey = "EnterPlayModeOptionsEnabled";
    private const string EnterPlayModeOptionsPrefKey = "EnterPlayModeOptions";

    static EditorPlayModeSettingsToggle()
    {
        enterPlayModeOptionsEnabled = EditorPrefs.GetBool(EnterPlayModeOptionsEnabledPrefKey, EditorSettings.enterPlayModeOptionsEnabled);
        enterPlayModeOptions = (EnterPlayModeOptions)EditorPrefs.GetInt(EnterPlayModeOptionsPrefKey, (int)EditorSettings.enterPlayModeOptions);

        ToolbarExtender.LeftToolbarGUI.Add(ShowToggle);
    }

    private static void ShowToggle()
    {
        EditorGUI.BeginChangeCheck();
        GUILayout.BeginHorizontal();

        GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
        toggleStyle.normal.textColor = toggleStyle.onNormal.textColor = enterPlayModeOptionsEnabled ? Color.red : Color.green;
        toggleStyle.hover.textColor = toggleStyle.onHover.textColor = enterPlayModeOptionsEnabled ? Color.red : Color.green;
        toggleStyle.active.textColor = toggleStyle.onActive.textColor = enterPlayModeOptionsEnabled ? Color.red : Color.green;
        toggleStyle.focused.textColor = toggleStyle.onFocused.textColor = enterPlayModeOptionsEnabled ? Color.red : Color.green;

        enterPlayModeOptionsEnabled = GUILayout.Toggle(enterPlayModeOptionsEnabled, "Play Mode Options Enable", toggleStyle);

        GUILayout.EndHorizontal();

        if (EditorGUI.EndChangeCheck())
        {
            EditorSettings.enterPlayModeOptionsEnabled = enterPlayModeOptionsEnabled;
            EditorPrefs.SetBool(EnterPlayModeOptionsEnabledPrefKey, enterPlayModeOptionsEnabled);

            EditorSettings.enterPlayModeOptions = enterPlayModeOptions;
            EditorPrefs.SetInt(EnterPlayModeOptionsPrefKey, (int)enterPlayModeOptions);
        }
    }
}