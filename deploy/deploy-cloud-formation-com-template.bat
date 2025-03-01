cd src/TorneSe.Pedidos.MinimalApi/

dotnet publish -c Release -r linux-x64 --self-contained false -o ../../publish

cd ../../publish
Compress-Archive -Path * -DestinationPath ../TorneSe.Pedidos.MinimalApi.zip -Force
cd ..

aws s3 mb s3://torne-se-pedidos-minimal-api-cloudformation --region us-east-1


aws s3 cp TorneSe.Pedidos.MinimalApi.zip s3://torne-se-pedidos-minimal-api-cloudformation --region us-east-1

cd deploy

aws cloudformation create-stack --stack-name torne-se-pedidos-minimal-api-cloudformation --template-body file://cloud-formation-api-pedidos.yml --region us-east-1 --capabilities CAPABILITY_NAMED_IAM

aws cloudformation wait stack-create-complete --stack-name torne-se-pedidos-minimal-api-cloudformation

aws cloudformation describe-stacks --stack-name torne-se-pedidos-minimal-api-cloudformation --query "Stacks[0].Outputs[?OutputKey=='ApiGatewayUrl'].OutputValue" --output text