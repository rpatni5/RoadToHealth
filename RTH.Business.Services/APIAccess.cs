﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public enum APIMethod
    {
        UserLogin,
        RegisterUser,
        GetUserTimelines,
        GetQuestionaires,
        GetInsights,
        ForgotPassword,
        RequestAccessCode,
        GetOAuthToken,
        GetLanguages,
        GetVariable,
        ValidateSocialLogin,
        SocialRegistration,
        TwitterGetRequestToken,
        TwitterGetAccessToken,
        TwitterGetUserInfo,
        TwitterPostTweet,
        VersionInfo,

    }
    public static class APIAccess
    {
        private static Dictionary<APIMethod, String> m_MethodUrls = new Dictionary<APIMethod, string>
        {
            { APIMethod.UserLogin, "users/api/login/" },
            { APIMethod.RegisterUser, "users/api/register/" },
            { APIMethod.GetUserTimelines,"apis/get_user_timelines" },
            { APIMethod.GetQuestionaires, "" },
            { APIMethod.GetInsights, "" },
            { APIMethod.ForgotPassword, "apis/user/forgotpassword" },
            { APIMethod.RequestAccessCode,"apis/user/forgotpassword/requestCode" },
            { APIMethod.GetOAuthToken, "oauth/token" },
            { APIMethod.GetLanguages, "apis/get_languages/''" },
            { APIMethod.GetVariable, "" }    ,
            { APIMethod.ValidateSocialLogin, "users/api/sociallogin/" }    ,
            { APIMethod.SocialRegistration, "users/api/register/socialmedia/" }    ,
            { APIMethod.TwitterGetRequestToken, "oauth/request_token" }    ,
            { APIMethod.TwitterGetAccessToken, "oauth/access_token" }    ,
            { APIMethod.TwitterGetUserInfo, "users/show.json" }    ,
            { APIMethod.TwitterPostTweet, "statuses/update.json" }    ,
            {APIMethod.VersionInfo, "apis/get_latest_version/2/en" },
        };

        public static string GetMethodUri(this APIMethod method)
        {
            if (m_MethodUrls.ContainsKey(method))
            {
                return m_MethodUrls[method];
            }
            throw new ArgumentException("method");
        }

    }



}
