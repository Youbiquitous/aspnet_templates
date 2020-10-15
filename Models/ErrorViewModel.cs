///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//  

using System;
using $safeprojectname$.Common.Exceptions;

namespace $safeprojectname$.Models
{
    public class ErrorViewModel : MainViewModelBase
    {
        public MinimoException Error { get; private set; }

        public string Path { get; set; }

        public void SetError(Exception error)
        {
            if (error is MinimoException exception)
                Error = exception;
            else
                Error = new MinimoException(error);
        }

        public bool HasError()
        {
            return Error != null;
        }
    }
}