# lambda-auth

## Instruções para deploy no AWS Lambda

É necessário que as configurações de acesso ao AWS já estejam configuradas.

Instruções de configuração em [AWS Comand Line Interface](https://aws.amazon.com/pt/cli/#:~:text=AWS%20Command%20Line%20Interface%201%20aws-shell%20%28Developer%20Preview%29,easy%20to%20manage%20your%20Amazon%20S3%20objects.%20)


### Siga os passos:

1) Acesse a pasta do projeto com a função `src\LambadaAuth`;


2) Execute o comando: `dotnet lambda deploy-function`;

![command deploy](./docs/lambda-command-deploy.png)


3) Informe o nome da função: `LambdaAuthFiap`

![function name](./docs/lambda-function-name.png)


4) Informe o nome IAM Role: `RoleLambdaAuthFiap`

![IAM role name](./docs/lambda-iam-role-name.png)


5) Selecione IAM Policy: `4 - AWSLambdaBasicExecutionRole`

![IAM role name](./docs/lambda-iam-policy.png)


Ao final do processo, a função lambda estará disponível no console da AWS.

![lambda console aws](./docs/lambda-console.png)



## Instruções de configuração da API Gateway

### Siga os passos:

1) Após a publicação selecione no console a função Lambda criada.


2) Adicione um gatilho da função lambda.

![lambda console aws](./docs/lambda-add-gatilho.png)


3) Selecione `API Gateway`.

![lambda api gateway](./docs/lambda-add-apigateway.png)


4) Crie a API Gateway com os seguintes parâmetros:

- API Type: `REST API`
- Security: `Open`

![api gateway create](./docs/api-gateway-create.png)


5) Após a criação, o endpoint de acesso já estará disponível.

![api gateway endpoint](./docs/api-gateway-endpoint.png)


## Porém, para que a API aceite os parâmetros configurados, ainda será necessário configurar a forma de Integração da Requisição.

### Siga os passos:

1) Clique sobre a `Solicitação de Integração`.

![api gateway integration request](./docs/api-gateway-integracao.png)


2) Desmarque a opção `Usar a integração de proxy do Lambda`.

![api gateway config](./docs/api-gateway-config.png)


3) Por fim, clique no botão `Ações` e, na sequência em `Implantar API`.

![api gateway deploy](./docs/api-gateway-deploy.png)


Pronto, o acesso à função Lambda pelo API Gateway já está disponível.
