# ASPNET using Keycloak

## Run Keycloak

`docker-compose up -d`

An instance of latest Keycloak will be available on `http://localhost:8080`

### Import demo realm

Create a new `realm` with name `demo` importing the file `realm-export.json`.

## WebApiRoleBased (Code Authorization)

```
GET /weatherforecast
```

Required role `CommonUser`

```
POST /weatherforecast
```

Required role `Admin`

> webapi1 folder on Postman collection has the two requests already configured

## WebApiSample (Client Credentials Authorization)

```
GET /weatherforecast
```

Required scope `read:weatherforecast`

```
POST /weatherforecast
```

Required scope `write:weatherforecast`

### Configure client secret

A client `webapp1` is created, but it needs a secret, go to `Clients > webapi1 > Credentials` to generate.

### Generate access token

```curl
curl --location --request POST 'http://localhost:8080/realms/demo/protocol/openid-connect/token' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'client_id=webapi1' \
--data-urlencode 'client_secret=[secret here]' \
--data-urlencode 'grant_type=client_credentials'
```

## SPA Sample

Open https://www.keycloak.org/app/ and setup:


```
url: http://localhost:8080
realm: demo
client: spa-demo
```

Now you can click Sign in to authenticate to this application using the Keycloak server you started earlier.