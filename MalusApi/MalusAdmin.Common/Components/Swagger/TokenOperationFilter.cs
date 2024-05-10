using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common
{
    public class TokenOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorizeAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<AuthorizeAttribute>();

            if (authorizeAttributes.Any())
            {
                operation.Parameters ??= new List<OpenApiParameter>();

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Token",
                    In = ParameterLocation.Header,
                    Description = "Access Token",
                    Required = true, // 根据你的需求设定是否为必需
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });

                //var bearerScheme = new OpenApiSecurityScheme
                //{
                //    Scheme = "Bearer",
                //    Reference = new OpenApiReference
                //    {
                        
                //        Type = ReferenceType.Header,
                //        Id = "Token"
                //    }
                //};

                //operation.Security = new List<OpenApiSecurityRequirement>
                //{
                //    new OpenApiSecurityRequirement()
                //    {
                //        [ bearerScheme ] = Array.Empty<string>()
                //    }
                //};
            }


        }
    }
}