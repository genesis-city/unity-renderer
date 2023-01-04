using DCL.Social.Friends;
using System;
using UnityEngine;

namespace DCL.Chat.Notifications
{
    public interface IMainChatNotificationsComponentView
    {
        event Action<bool> OnResetFade;
        event Action<bool> OnPanelFocus;
        event Action<string> OnClickedFriendRequest;

        Transform GetPanelTransform();
        void AddNewChatNotification(PrivateChatMessageNotificationModel model);
        void AddNewChatNotification(PublicChannelMessageNotificationModel model);
        void AddNewFriendRequestNotification(FriendRequestNotificationModel model);
        void Show(bool instant = false);
        void Hide(bool instant = false);
        void ShowNotifications();
        void HideNotifications();
        void ShowPanel();
        void HidePanel();
    }
}