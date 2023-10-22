using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Auth.Models;
using Auth.Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Auth;

public class Function
{
    //Desabilitar na AWS em Lambda/Resources ANY -> Integration Request -> Use Lambda Proxy Integration
    //Executar Action -> Deploy API
    public Output Login(Usuario input, ILambdaContext context)
    {
        return new Output{
            StatusCode = 200,
            Result = TokenService.GenerateToken(input)
        };
    }
}
