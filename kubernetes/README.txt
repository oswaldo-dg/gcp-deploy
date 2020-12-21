
Namespace for deploymnet 
gcp-deployment

1. gcp-namespace.yaml
	Define namespace 'gcp-deployment' for resource allocation

2. gcp-kong-dbless.yaml
	Creates all the resources related to get Kong-Ingress running on K8s

3. gcp-ssl-secret.yaml
	Create a secret for SSL Certificate & PK, both should be set as base64

4. gcp-api-ingress.yaml
	Defina ingress rules for API microservices
	
5. gcp-api-services.yaml
	Load all API services and ports
	
6. thm-api-pod.yaml
	Create a pod hosting required container for THM
	
Test
curl -i [EXTERNAL_IP]
Should return HTTP/1.1 404 Not Found

curl -i http://[EXTERNAL_IP]/services/identity/health
Should return HTTP/1.1 200 OK	
	