﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Helpers.Messaging
{
    public enum MessageType
    {
        Message,
        LoadView,
        UpdatedEmail,
        UpdatedPassword,
        UpdatedFullName,
        ConnectToTwitter,
        ConnectToFacebook,
        ExecuteBack,
        AnimateHRA,
        RefreshComplete,
        StrategyAdded,
        HealthQuestionaire,
        HealthPlanLoaded,
        SaveCredentialAndLoadChatView,
        StartChat
    }
}
