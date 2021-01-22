FROM node:14.1-alpine as build-deps
WORKDIR /app
COPY . ./

ENV PATH="./ui/gcp-ui/node_modules/.bin:$PATH"

WORKDIR /app/ui/gcp-ui/
RUN npm install -g @angular/cli
RUN yarn install
RUN ng build --prod

# stage: 2 — the production environment
FROM nginx:1.12-alpine
COPY --from=build-deps /app/ui/gcp-ui//dist/gcp-ui/ /usr/share/nginx/html

RUN apk update && apk add ca-certificates && rm -rf /var/cache/apk/*
COPY ["resources/cacertpem.crt", "/usr/local/share/ca-certificates/cacertpem.crt"]
RUN update-ca-certificates


EXPOSE 80
EXPOSE 443
CMD ["nginx", "-g", "daemon off;"]
