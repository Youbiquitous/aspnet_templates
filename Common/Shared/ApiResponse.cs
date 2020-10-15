///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace $safeprojectname$.Common.Shared
{
    public class ApiResponse
    {
        public static ApiResponse Ok = new ApiResponse(true);
        public static ApiResponse Fail = new ApiResponse();

        public ApiResponse(bool success = false, string message = "")
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string ExtraData { get; private set; }

        public ApiResponse AddMessage(string message)
        {
            Message = message;
            return this;
        }

        public ApiResponse AddExtra(string data)
        {
            ExtraData = data;
            return this;
        }

        public static ApiResponse FromCommand(CommandResponse response)
        {
            var apiResponse = new ApiResponse(response.Success);
            apiResponse.AddExtra(response.ExtraData);
            apiResponse.AddMessage(response.Message);
            return apiResponse;
        }
    }
}