/* Auto Assign Hotkey addon for SURIYUN's MMORPG KIT. */
using System.Collections.Generic;

namespace MultiplayerARPG
{
    public static partial class PlayerCharacterDataExtensions
    {
        /// <summary>
        /// This extension method will be called when setting up a new character. It will assign any skills that are
        /// level 1 or higher to the hotkey slots (until running out of available slots).
        /// </summary>
        [DevExtMethods("SetNewCharacterData")]
        public static void SetNewCharacterData_AutoAssignHotkeys(IPlayerCharacterData character, string characterName,
            int dataId, int entityId)
        {
            if (GameInstance.Singleton == null || !GameInstance.Singleton.autoAssignHotkeys)
                return;

            string[] hotkeyIDs = GameInstance.Singleton.hotkeysToAssign;
            Dictionary<BaseSkill, int> skills = character.GetSkills(true);
            if (skills == null || hotkeyIDs == null)
                return;

            int hotkeyIndex = 0;
            foreach (KeyValuePair<BaseSkill, int> skillData in skills)
            {
                if (hotkeyIndex >= hotkeyIDs.Length)
                    return; // No more hotkey slots left

                BaseSkill skill = skillData.Key;
                int skillLevel = skillData.Value;
                if (skillLevel > 0 && skill != null && !skill.IsPassive) // Don't assign unlearned or passive skills
                {
                    character.Hotkeys.Add(new CharacterHotkey()
                    {
                        hotkeyId = hotkeyIDs[hotkeyIndex++],
                        relateId = skill.Id,
                        type = HotkeyType.Skill
                    });
                }
            }
        }
    }
}
