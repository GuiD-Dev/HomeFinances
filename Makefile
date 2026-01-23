init-db:
	docker run -p 5432:5432 -e POSTGRES_PASSWORD=1234 --name postgres -d postgres:18

watch-webapi:
	dotnet watch --project HomeFinances.WebApi/HomeFinances.WebApi.API

add-migration:
	dotnet ef migrations add $(name) \
		--project HomeFinances.WebApi/HomeFinances.WebApi.Infrastructure \
		--startup-project HomeFinances.WebApi/HomeFinances.WebApi.API

build-webapi:
	docker build --no-cache -f docker/webapi.dockerfile -t home-finances-webapi .

build-frontend:
	docker build --no-cache -f docker/frontend.dockerfile -t home-finances-frontend .

run-app:
	docker compose -f docker/docker-compose.yml up -d