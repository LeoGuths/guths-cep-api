# Guths.Cep.Api 🏢📦

API de consulta de CEP com fallback para múltiplos provedores, garantindo alta disponibilidade e precisão dos dados.

## ✨ Funcionalidades

- Consulta de CEP por número (ex: `01001000`)
- Fallback automático entre provedores (ordem de prioridade não configurável)
- Dados padronizados em formato JSON
- Scalar/OpenAPI integrado para teste interativo
- Leve e rápida (construída com .NET 9.0)
- Pronta para Docker/Podman

## 🔍 Provedores Suportados

1. **ViaCEP** (primário)
2. **OpenCEP** (fallback 1)
3. **ApiCEP** (fallback 2)
4. **BrasilAberto** (fallback 3) -> Temporariamente desativado devido a problemas de autenticação
5. **BrasilAPI** (fallback 4)

## 🚀 Como Usar

### Exemplo de requisição:
```bash
GET /api/cep/{cep}
```

```bash
curl -X GET "http://localhost:8080/api/cep/01001000"
```

### Resposta de sucesso (200 OK)
```csharp
{
  "zipCode": "70040-010",
  "street": "Quadra SBN Quadra 1",
  "neighborhood": "Asa Norte",
  "city": "Brasília",
  "uf": "DF",
  "state": "Distrito Federal", // ou null caso o provedor não retorne
  "provider": "ViaCep"
}
```

## 🐳 Executando com Docker/Podman

### Construa a imagem
```bash
podman build -t guths-cep-api .
```

```bash
docker build -t guths-cep-api .
```

### Execute o container
```bash
podman run -p 8080:8080 -p 8081:8081 -e ASPNETCORE_ENVIRONMENT=Development guths-cep-api
```

```bash
docker run -p 8080:8080 -p 8081:8081 -e ASPNETCORE_ENVIRONMENT=Development guths-cep-api
```

## 🐳 Executando com Docker/Podman

### Pré-requisitos
- .NET 9.0 SDK
- Podman/Docker