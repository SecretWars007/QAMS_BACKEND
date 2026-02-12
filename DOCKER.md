Docker quickstart

Build and run with Docker Compose (builds the API image and starts Postgres):

```bash
# build and start in background
docker-compose up --build -d

# view service status
docker-compose ps

# follow logs
docker-compose logs -f
```

Run API image directly (for debugging):

```bash
# build image
docker build -t qams-api:local .

# run container exposing port 5000 (host) -> 8080 (container)
docker run --rm -p 5000:8080 --env-file ./src/QAMS.Api/appsettings.Docker.env qams-api:local
```

Notes:
- The `Dockerfile` at repository root builds the entire solution and publishes the `QAMS.Api` project.
- `docker-compose.yml` already configures Postgres and the `api` service. Use the `--build` flag to ensure the image uses the updated Dockerfile.
