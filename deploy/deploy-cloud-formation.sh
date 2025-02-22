# Cria o bucket para armazenar os arquivos da aplicação
aws s3 mb s3://torne-se-pedidos-minimal-api-cloudformation --region us-east-1

# Faz o deploy da aplicação
cd src/TorneSePedidos.MinimalApi

# Publica a aplicação
dotnet-lambda deploy-serverless --stack-name torne-se-pedidos-minimal-api-cloudformation --s3-bucket torne-se-pedidos-minimal-api-cloudformation --region us-east-1