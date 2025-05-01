FROM nginx:alpine

# Nginx yapýlandýrma dosyalarýný kopyala
COPY ./nginx/nginx.conf /etc/nginx/nginx.conf
COPY ./nginx/sites-available /etc/nginx/sites-available
COPY ./nginx/certs /etc/nginx/certs

# sites-available'dan sites-enabled'a sembolik baðlantý oluþtur
RUN mkdir -p /etc/nginx/sites-enabled
RUN ln -s /etc/nginx/sites-available/onuraydi.com.tr /etc/nginx/sites-enabled/

EXPOSE 80 443