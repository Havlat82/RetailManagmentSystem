using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;

// https://stackoverflow.com/questions/51117655/how-to-use-swagger-in-asp-net-webapi-2-0-with-token-based-authentication

namespace RetailManagmentSystem.DataManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            var tags = new List<string> { "Auth" };
            var consumes = new List<string> { "application/x-www-form-urlencoded" };

            var parameters = new List<Parameter> {
                CreateParameter("grant_type", "string", "formData", "password", true),
                CreateParameter("username", "string", "formData", null, false),
                CreateParameter("password", "string", "formData", null, false)
            };

            swaggerDoc.paths.Add("/token", new PathItem { post = CreatePostOperation(tags, consumes, parameters) });
        }

        private Operation CreatePostOperation(List<string> tags, List<string> consumes, List<Parameter> parameters)
        {
            var o = new Operation
            {
                tags = tags,
                consumes = consumes,
                parameters = parameters
            };
            return o;
        }

        private Parameter CreateParameter(string name, string type, string @in, string @default, bool required)
        {
            var p = new Parameter
            {
                type = type,
                name = name,
                required = required,
                @in = @in,
                @default = @default
            };
            return p;
        }
    }
}