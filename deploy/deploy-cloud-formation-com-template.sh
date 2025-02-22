cd src/TorneSe.Pedidos.MinimalApi/

dotnet publish -c Release -r linux-x64 --self-contained false -o ../../publish

# Zip the project
cd ../../publish
#windows
Compress-Archive -Path * -DestinationPath ../TorneSe.Pedidos.MinimalApi.zip -Force
#linux
# zip -r ../TorneSe.Pedidos.MinimalApi.zip .
cd ..
# 7z
# 7z a -tzip ../TorneSe.Pedidos.MinimalApi.zip * -mx=9 -y

# Create S3 bucket
aws s3 mb s3://torne-se-pedidos-minimal-api-cloudformation --region us-east-1

# Upload the project to the S3 bucket
aws s3 cp TorneSe.Pedidos.MinimalApi.zip s3://torne-se-pedidos-minimal-api-cloudformation --region us-east-1

cd deploy

# Create CloudFormation stack
aws cloudformation create-stack --stack-name torne-se-pedidos-minimal-api-cloudformation --template-body file://cloud-formation-api-pedidos.yml --region us-east-1 --capabilities CAPABILITY_NAMED_IAM

aws cloudformation wait stack-create-complete --stack-name torne-se-pedidos-minimal-api-cloudformation

aws cloudformation describe-stacks --stack-name torne-se-pedidos-minimal-api-cloudformation --query "Stacks[0].Outputs[?OutputKey=='ApiGatewayUrl'].OutputValue" --output text