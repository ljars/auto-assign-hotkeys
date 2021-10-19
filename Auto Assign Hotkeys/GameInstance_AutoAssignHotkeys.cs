/* Auto Assign Hotkey addon for SURIYUN's MMORPG KIT. */
using UnityEngine;

namespace MultiplayerARPG
{
    public partial class GameInstance
    {
        /// <summary>
        /// To disable this addon, set this value to false on the GameInstance object in your Init scene(s).
        /// </summary>
        [Tooltip("When true, pre-unlocked skills will be assigned to hotkeys when creating a new character."),
         Header("Addon: AutoAssignHotkeys")]
        public bool autoAssignHotkeys = true;
        
        /// <summary>
        /// This specifies by hotkeyID which hotkeys will be assigned skills. The hotkeys will be assigned in the order
        /// their IDs appear in this array. These should match the hotkeyID in the uiCharacterHotkeys array of the
        /// UICharacterHotkeys component (look in your CanvasGameplay prefab).
        /// </summary>
        [Tooltip("These are the hotkeys to assign skills to. Each should match a hotkeyID in UICharacterHotkeys.")]
        public string[] hotkeysToAssign = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
    }
}
