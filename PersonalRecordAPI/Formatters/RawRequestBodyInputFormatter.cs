﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

/// <summary>
/// Formatter that allows content of type text/plain and application/octet stream
/// or no content type to be parsed to raw data. Allows for a single input parameter
/// in the form of:
/// 
/// public string RawString([FromBody] string data)
/// public byte[] RawData([FromBody] byte[] data)
///
/// This code is courtesy of the following website:
/// https://weblog.west-wind.com/posts/2017/sep/14/accepting-raw-request-body-content-in-aspnet-core-api-controllers#Create-an-MVC-InputFormatter
/// NOTE: Some modifications had to be made to make this work with .net core 2.2.
/// </summary>
///
public class RawRequestBodyFormatter : InputFormatter
{
    public RawRequestBodyFormatter()
    {
        SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
    }


    /// <summary>
    /// Allow text/plain, application/octet-stream and no content type to
    /// be processed
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override Boolean CanRead(InputFormatterContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        var contentType = context.HttpContext.Request.ContentType;
        if (string.IsNullOrEmpty(contentType) || contentType == "text/plain" ||
            contentType == "application/octet-stream")
            return true;

        return false;
    }

    /// <summary>
    /// Handle text/plain or no content type for string results
    /// Handle application/octet-stream for byte[] results
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var request = context.HttpContext.Request;
        var contentType = context.HttpContext.Request.ContentType;


        if (string.IsNullOrEmpty(contentType) || contentType == "text/plain")
        {
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                return await InputFormatterResult.SuccessAsync(content);
            }
        }
        if (contentType == "application/octet-stream")
        {
            using (var ms = new MemoryStream(2048))
            {
                await request.Body.CopyToAsync(ms);
                var content = ms.ToArray();
                return await InputFormatterResult.SuccessAsync(content);
            }
        }

        return await InputFormatterResult.FailureAsync();
    }
}