///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
// 


namespace $safeprojectname$.Infrastructure.Services
{
    public interface IFileService
    {
        string Load(string path, bool removeComments = true);
        void Save(string path, string content);
    }
}