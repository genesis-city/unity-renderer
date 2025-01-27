using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DCL
{
    public class EquippedEmoteData
    {
        public string id;
        public Sprite cachedThumbnail;
    }

    public class DataStore_EmotesCustomization
    {
        public readonly BaseVariable<bool> isWheelInitialized = new (false);
        public readonly BaseCollection<EquippedEmoteData> unsavedEquippedEmotes = new (new List<EquippedEmoteData> { null, null, null, null, null, null, null, null, null, null });
        public readonly BaseCollection<EquippedEmoteData> equippedEmotes = new (new List<EquippedEmoteData> { null, null, null, null, null, null, null, null, null, null });
        public readonly BaseVariable<bool> isEmotesCustomizationSelected = new (false);
        public readonly BaseCollection<string> currentLoadedEmotes = new ();

        public void UnequipMissingEmotes(IEnumerable<WearableItem> emotes)
        {
            var setOfIds = new HashSet<string>();
            foreach (var emote in emotes)
                setOfIds.Add(emote.id);

            for (int i = 0; i < equippedEmotes.Count(); i++)
            {
                if (equippedEmotes[i] != null && !setOfIds.Contains(equippedEmotes[i].id))
                    equippedEmotes[i] = null;
            }
        }
    }
}
