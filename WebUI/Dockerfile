FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY publish .
COPY ../nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
EXPOSE 443
CMD ["nginx", "-g", "daemon off;"] 