#!/bin/bash
echo "Docker Compose ile projeyi ba�lat�yor..."
docker-compose down
docker-compose up -d --build
