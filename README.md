# API RESTful com .NET, MongoDB, Redis e Docker

Este projeto é uma API RESTful desenvolvida com .NET Core, MongoDB, Redis e Docker. A API permite realizar operações CRUD (Create, Read, Update, Delete) para gerenciar notícias. O Redis é utilizado para cache das notícias, melhorando o desempenho das consultas.

## Tecnologias Utilizadas

- **.NET Core**: Framework de desenvolvimento para criar APIs robustas e escaláveis.
- **MongoDB**: Banco de dados NoSQL para armazenar as notícias.
- **Redis**: Sistema de cache para melhorar a performance da API.
- **Docker**: Ferramenta para containerizar a aplicação e suas dependências.

## Pré-requisitos

Antes de rodar o projeto, você precisa ter o seguinte instalado:

- [Docker](https://www.docker.com/products/docker-desktop)
- [SDK .NET 6](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community) (caso não use Docker para MongoDB)
- [Redis](https://redis.io/download) (caso não use Docker para Redis)

## Instruções de Configuração

### 1. Configure o Docker (se necessário)

Se você for utilizar o Docker para MongoDB e Redis, você pode rodar os seguintes containers:

#### MongoDB:

```bash
docker run --name mongodb -d -p 27017:27017 mongo
```

##### Redis:
```bash
docker run --name redis -d -p 6379:6379 redis
```

#### 2. Crie o arquivo de configuração de ambiente
Copie o arquivo appsettings.Development.json.example para appsettings.Development.json e preencha as informações do banco de dados e outros detalhes conforme necessário.

#### 3. Instale as dependências do projeto
Navegue até a pasta do projeto e execute o comando para restaurar as dependências:

```bash

dotnet restore
```
#### 4. Compile e execute o projeto

Execute o projeto com o comando:

```bash

dotnet run
```
A API estará disponível em http://localhost:44348.

#### 5. Acesse a API

Você pode usar ferramentas como Postman ou curl para interagir com os endpoints da API.

**Endpoints da API**

A API fornece os seguintes endpoints para interagir com as notícias:

_GET /api/news_: Retorna todas as notícias.

Exemplo de requisição:

```bash
curl -X GET http://localhost:44348/api/news
POST /api/news: Cria uma nova notícia.
```

Exemplo de requisição:

```bash
curl -X POST http://localhost:44348/api/news -H "Content-Type: application/json" -d '{
  "title": "Nova Notícia",
  "text": "Texto da notícia",
  "author": "Autor da Notícia",
  "img": "url_da_imagem",
  "link": "https://link-da-noticia.com",
  "status": 1,
  "publishDate": "2024-12-14T22:27:32.167Z"
}'
```
_GET /api/news/{id}_: Retorna uma notícia específica pelo ID.

Exemplo de requisição:

```bash
curl -X GET http://localhost:44348/api/news/{id}
```
_GET /api/news/cache_: Retorna as notícias com cache utilizando Redis.

Exemplo de requisição:

```bash
curl -X GET http://localhost:44348/api/news/cache
```

**Configuração de Ambiente**

Você pode configurar variáveis de ambiente no arquivo _appsettings.Development.json_ para personalizar a conexão com o MongoDB, Redis, entre outros.

Exemplo de configuração:
```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://root:mypassword@localhost:27017/db_local?authSource=admin",
    "Redis": "localhost:6379"
  }
}
```

**MongoDB:** O MongoDB está configurado para autenticação com o usuário e senha, no banco de dados db_local. O authSource=admin define que a autenticação ocorre no banco de dados admin.

**Redis:** A configuração utiliza localhost para se conectar ao Redis.

**Testes:**
Para testar a API, você pode usar ferramentas como Postman ou Swagger UI (caso tenha o Swagger configurado na API).

Abra o Postman e crie requisições para os endpoints mencionados.

Verifique se a API está funcionando corretamente, especialmente as operações de CRUD.
Caso o Swagger esteja configurado, você pode acessar a interface de testes diretamente pelo navegador em _http://localhost:44348/swagger_.

**Dockerfile**

O Dockerfile presente no projeto permite containerizar a aplicação e executá-la em um ambiente isolado. Para rodar a API dentro de um container Docker, execute os seguintes comandos:


**Construir a imagem Docker:**

```bash
docker build -t api-restful .
```
**Rodar o container:**

```bash
docker run -d -p 44348:44348 api-restful
```
Esses comandos vão construir e executar a API dentro de um container Docker, tornando a aplicação acessível via _http://localhost:44348_.

