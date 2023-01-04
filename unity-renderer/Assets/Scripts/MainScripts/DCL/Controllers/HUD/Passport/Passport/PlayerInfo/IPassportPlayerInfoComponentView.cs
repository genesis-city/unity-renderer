using DCl.Social.Friends;
using System;
using SocialFeaturesAnalytics;
using DCL.Social.Friends;
using UIComponents.Scripts.Components;

namespace DCL.Social.Passports
{
    public interface IPassportPlayerInfoComponentView : IBaseComponentView<PlayerPassportModel>
    {
        event Action OnAddFriend;
        event Action OnRemoveFriend;
        event Action OnCancelFriendRequest;
        event Action OnAcceptFriendRequest;
        event Action OnBlockUser;
        event Action OnUnblockUser;
        event Action OnReportUser;
        event Action<string> OnWhisperUser;

        void SetIsBlocked(bool isBlocked);
    }
}