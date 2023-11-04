using Amazon.Lambda.Annotations;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Auth.Models;
using Auth.Services;
using LambdaAuth.BusinessObjects;
using LambdaAuth.Data;
using System;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Auth;

public class Function
{
    private ClienteRepository _repository;

    //public Function(ClienteContext context) {
    //    Db = context;
    //}

    //Desabilitar na AWS em Lambda/Resources ANY -> Integration Request -> Use Lambda Proxy Integration
    //Executar Action -> Deploy API
    public Output Login(string cpf, ILambdaContext context)
    {
        _repository = new ClienteRepository();
        Cliente? cliente = _repository.GetByCpf(cpf);

        //Cliente? cliente = Db.Clientes.FirstOrDefault(cliente => cliente.Cpf == cpf);
        if (cliente == null)
            return new Output
            {
                StatusCode = 400,
                Result = ""
            };


        return new Output{
            StatusCode = 200,
            Result = TokenService.GenerateToken(cliente)
        };
    }
}
