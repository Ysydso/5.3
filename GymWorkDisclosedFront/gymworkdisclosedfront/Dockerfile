FROM node:18-alpine AS deps

WORKDIR /app

COPY package.json ./
RUN npm install

COPY next.config.js ./next.config.js

COPY app ./app
COPY public ./public
COPY tailwind.config.js .
COPY /postcss.config.js .
CMD ["npm", "run", "dev"]
