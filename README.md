# ASPNET using Keycloak

## Run Keycloak

`docker-compose up -d`

An instance of latest Keycloak will be available on `http://localhost:8080`

### Import demo realm

Create a new `realm` importing the file `realm-export.json`.

### Configure client secret

A client `client-one` is created, but it needs a secret, go to `Clients > client-one > Credentials` to generate.

## Generate access token

```curl
curl --location --request POST 'http://localhost:8080/realms/demo/protocol/openid-connect/token' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'client_id=client-one' \
--data-urlencode 'client_secret=[secret here]' \
--data-urlencode 'grant_type=client_credentials'
```