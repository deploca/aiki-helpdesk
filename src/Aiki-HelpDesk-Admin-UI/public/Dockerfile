FROM nginx:1.19.2-alpine

COPY . /usr/share/nginx/html
COPY nginx-default.conf /etc/nginx/conf.d/default.conf
RUN rm -rf /usr/share/nginx/html/nginx-default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]