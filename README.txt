podman build -t guths-cep-api .
podman run -p 8080:8080 -p 8081:8081 -e ASPNETCORE_ENVIRONMENT=Development guths-cep-api