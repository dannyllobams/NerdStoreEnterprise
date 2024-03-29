﻿using System;
using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public CustomHttpRequestException() { }

        public CustomHttpRequestException(string message, Exception innerException) 
            : base(message, innerException) { }

        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

    }
}
