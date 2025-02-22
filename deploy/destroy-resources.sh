# Delete bucket files
aws s3 rm s3://torne-se-pedidos-minimal-api-cloudformation --recursive --region us-east-1

# Delete S3 bucket
aws s3 rb s3://torne-se-pedidos-minimal-api-cloudformation --region us-east-1

# Delete IAM role policy
aws iam delete-role-policy --role-name torne-se-pedidos-minimal-api-cloudformation-role --policy-name torne-se-pedidos-minimal-api-cloudformation-policy --region us-east-1

# Delete IAM role
aws iam delete-role --role-name torne-se-pedidos-minimal-api-cloudformation-role --region us-east-1

# GET APIs Gateway
API_ID=$(aws apigateway get-rest-apis --region us-east-1 --query "items[0].id" --output text)

# Delete API Gateway
aws apigateway delete-rest-api --rest-api-id $API_ID --region us-east-1

# Delete Lambda function
aws lambda delete-function --function-name torne-se-pedidos-minimal-api --region us-east-1

# Delete CloudFormation stack
aws cloudformation delete-stack --stack-name torne-se-pedidos-minimal-api-cloudformation --region us-east-1