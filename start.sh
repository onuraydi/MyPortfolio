#!/bin/bash
echo "Docker Compose ile projeyi baþlatýyor..."
docker-compose down
docker-compose up -d --build
