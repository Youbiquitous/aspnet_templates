///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace $safeprojectname$.Common.Shared
{
    public class CommandResponse
    {
        public static CommandResponse Ok()
        {
            return new CommandResponse(true);
        }

        public static CommandResponse Fail()
        {
            return new CommandResponse();
        } 

        public CommandResponse(bool success = false, string message = "")
        {
            Success = success;
            Message = message;
            HasWarning = false;
            RedirectUrl = string.Empty;
            Key = "";
            ExtraData = "";
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string Key { get; private set; }
        public string ExtraData { get; private set; }
        public string RedirectUrl { get; private set; }
        public bool HasWarning { get; private set; }

        public CommandResponse Reset()
        {
            Message = "";
            HasWarning = false;
            Key = "";
            ExtraData = "";
            RedirectUrl = string.Empty;
            return this;
        }

        public CommandResponse AddMessage(string message)
        {
            Message = message;
            return this;
        }

        public CommandResponse AddKey(string key)
        {
            Key = key;
            return this;
        }

        public CommandResponse AddRedirectUrl(string url)
        {
            RedirectUrl = url;
            return this;
        }

        public CommandResponse AddExtra(string data)
        {
            ExtraData = data;
            return this;
        }

        public CommandResponse AddWarning()
        {
            HasWarning = true;
            return this;
        }
    }
}