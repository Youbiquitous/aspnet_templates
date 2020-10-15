///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
// 

using System;
using System.IO;
using System.Text;

namespace $safeprojectname$.Infrastructure.Services
{
    /// <summary>
    /// Helper class to abstract loading of text files
    /// </summary>
    public class DefaultFileService : IFileService
    {
        private readonly string _root;

        public DefaultFileService(string root = "")
        {
            _root = root;
        }

        /// <summary>
        /// Load a (text) file optionally removing lines beginning with /, *, #
        /// </summary>
        /// <param name="path"></param>
        /// <param name="removeComments"></param>
        /// <returns></returns>
        public string Load(string path, bool removeComments = true)
        {
            var file = Path.Combine(_root, path);
            if (file == null)
                return null;

            var reader = new StreamReader(file);
            var text = reader.ReadToEnd();
            if (removeComments)
            {
                var builder = new StringBuilder();
                var lines = text.Split('\n');
                foreach (var line in lines)
                {
                    var temp = line.Trim();
                    if (temp.StartsWith("/") || temp.StartsWith("*") || temp.StartsWith("#"))
                        continue;
                    builder.AppendLine(temp);
                }

                text = builder.ToString();
            }
            
            reader.Close();
            return text;
        }

        /// <summary>
        /// When implemented, it will save (text) content back to a file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public void Save(string path, string content)
        {
            throw new NotImplementedException();
        }
    }
}