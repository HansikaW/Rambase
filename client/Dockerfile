### STAGE : Build ###
FROM node:12.8-alpine AS build
WORKDIR /src/app
COPY package.json ./
RUN npm install --verbose
COPY . .
RUN npm run build

### STAGE2: Run ###
 FROM nginx:1.17.1-alpine
 COPY --from=build ./dist/FrontEnd /usr/share/nginx/html 
